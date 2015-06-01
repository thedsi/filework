using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace filework
{
    class Engine : IDisposable
    {
        Control parent; //need this in order to send events in UI thread

        Thread workerThread;
        AutoResetEvent   workerChangeIntervalEvent;
        AutoResetEvent   workerTerminateEvent;
        ManualResetEvent workerScanNowEvent;

        public Settings settings;
        public DateTime WorkStart { get; private set; }
        public DateTime NextScan { get; private set; }
        public ScanFile CurrentFile { get; private set; }
        public delegate void OnEngineUpdateFn();
        public event OnEngineUpdateFn OnEngineUpdate;

        public enum EngineStates
        {
            Paused,        // Пауза
            WaitScan,      // Нет файлов
            Scanning,      // Сканирование
            CopyingToWork, // Копирование файла в Work
            Processing,    // Обработка файла скриптом
            MovingToDone,  // Перемещение из Input в Done
        }
        EngineStates State_;

        public EngineStates State
        {
            get { return State_;  }
            private set { State_ = value; SendEngineUpdate(); }
        }

        public string GetStatus()
        {
            string status = "";
            switch (State)
            {
                case EngineStates.WaitScan:
                    status = "Нет файлов - следующее сканирование через " + (int)(NextScan - DateTime.Now).TotalSeconds + "с";
                    break;
                case EngineStates.Paused:
                    status = "Пауза.";
                    break;
                case EngineStates.Processing:
                    status = "Обработка \"" + CurrentFile.Filename + "\" " +
                        (int)(DateTime.Now - WorkStart).TotalMinutes + "м...";
                    break;
                case EngineStates.CopyingToWork:
                    status = "Обработка \"" + CurrentFile.Filename + "\" " +
                        (int)(DateTime.Now - WorkStart).TotalMinutes + "м - Копирование в Work...";
                    break;
                case EngineStates.MovingToDone:
                    status = "Обработка \"" + CurrentFile.Filename + "\" " +
                        (int)(DateTime.Now - WorkStart).TotalMinutes + "м - Перемещение в Done...";
                    break;
                case EngineStates.Scanning:
                    status = "Сканирование " +
                        (int)(DateTime.Now - WorkStart).TotalSeconds + "с...";
                    break;
            }
            return status;
        }

        public void SetPause(bool bPause)
        {
            settings.Pause = bPause;
            workerChangeIntervalEvent.Set();
        }

        public void SetInterval(int interval)
        {
            settings.Interval = interval;
            workerChangeIntervalEvent.Set();
        }


        public Engine(Control parent)
        {
            this.parent = parent;
            settings = new Settings("settings.xml");
            workerChangeIntervalEvent = new AutoResetEvent(false);
            workerTerminateEvent = new AutoResetEvent(false);
            workerScanNowEvent = new ManualResetEvent(false);

            workerThread = new Thread(WorkerThread);
            workerThread.Start();
        }

        ~Engine()
        {
            Dispose();
        }

        void SendEngineUpdate()
        {
            if (OnEngineUpdate != null && parent != null)
            {
                parent.Invoke((MethodInvoker)delegate
                {
                    OnEngineUpdate();
                });
            }
        }

        public void ScanNow()
        {
            workerScanNowEvent.Set();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            workerTerminateEvent.Set();
            workerThread.Join();
            settings.Save();
        }

        //Returns true if should run new scan
        //Returns false if engine has requested worker thread termination
        bool Wait()
        {
            WaitHandle[] handles = new WaitHandle[]
            {
                workerTerminateEvent,      //0
                workerChangeIntervalEvent, //1
                workerScanNowEvent         //2
            };
            workerScanNowEvent.Reset();
            for (; ; )
            {
                int interval;
                if (!settings.Pause)
                {
                    interval = settings.Interval * 1000;
                    NextScan = DateTime.Now.AddMilliseconds(interval);
                    State = EngineStates.WaitScan;
                }
                else
                {
                    interval = -1;
                    State = EngineStates.Paused;
                }
                int result = WaitHandle.WaitAny(handles, interval, false);
                if (result == 0) //Terminate Event
                {
                    return false;
                }
                else if (result == 1) //Interval change/pause event
                {
                    continue; //recalculate interval
                }
                else //Scan now event or timeout
                {
                    return true;
                }
            }
        }

        void WorkerThread()
        {
            for (; ; )
            {
                ScanFile f = null;
                if (!settings.Pause)
                {
                    f = Scan();
                }

                if (f != null)
                {
                    ProcessFile(f);
                }
                else
                {
                    if (! Wait() ) return;
                }
            }
        }

        void SetupEnvironment(ScanFile file)
        {
            Environment.SetEnvironmentVariable("InputDir", settings.DirInput);
            Environment.SetEnvironmentVariable("OutputDir", settings.DirOutput);
            Environment.SetEnvironmentVariable("WorkDir", settings.DirWork);
            Environment.SetEnvironmentVariable("DoneDir", settings.DirDone);
            Environment.SetEnvironmentVariable("FileName", file.Filename);
            Environment.SetEnvironmentVariable("CleanName", file.Cleanname);
            Environment.SetEnvironmentVariable("CmdType", file.CmdType);
        }

        public void ProcessFile(ScanFile file)
        {
            CurrentFile = file;
            State = EngineStates.CopyingToWork;

            File.Copy(file.Fullname, settings.DirWork + @"\" + file.Filename, true);

            State = EngineStates.Processing;
            SetupEnvironment(file);
            string cmdfile = settings.GetRuleCmdFile(file.CmdType);
            string cmdargs = settings.GetRuleCmdArgs(file.CmdType);
            cmdfile = Environment.ExpandEnvironmentVariables(cmdfile);
            cmdargs = Environment.ExpandEnvironmentVariables(cmdargs);
            using (Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo();
                //p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = cmdfile;
                p.StartInfo.Arguments = cmdargs;
                //p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                p.Start();
                p.WaitForExit();
            }

            State = EngineStates.MovingToDone;
            File.Move(file.Fullname, settings.DirDone + @"\" + file.Filename);
        }

        //Выполнить сканирование, учитывая порядок сортировки.
        //Возвращает первый файл, для которого определено правило.
        public ScanFile Scan()
        {
            WorkStart = DateTime.Now;
            State = EngineStates.Scanning;
            try
            {
                //Get files in Input
                string[] files = Directory.GetFiles(settings.DirInput);

                //Sort
                if (settings.isAlphabetic)
                {
                    //Sort by name
                    Array.Sort(files);
                }
                else
                {
                    long[] sizes = new long[files.Length];
                    for (int i = 0; i < files.Length; i++)
                    {
                        sizes[i] = new FileInfo(files[i]).Length;
                    }
                    if (settings.isSmallFirst)
                    {
                        //Sort by size ascending
                        Array.Sort(sizes, files, Comparer<long>.Create(new Comparison<long>((a, b) => a.CompareTo(b))));
                    }
                    else
                    {
                        //Sort by size descending
                        Array.Sort(sizes, files, Comparer<long>.Create(new Comparison<long>((a, b) => b.CompareTo(a))));
                    }
                }

                //Try to find candidate for processing
                foreach (var file in files)
                {
                    try
                    {
                        ScanFile s = new ScanFile(file);
                        string Cmd = settings.GetRuleCmdFile(s.CmdType);
                        if (Cmd != null && !IsFileLocked(file))
                        {
                            return s; // use this candidate
                        }
                    }
                    catch { }
                }
            }
            catch { }
            return null;
        }

        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using (File.Open(filePath, FileMode.Open)) { }
            }
            catch (IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);

                return errorCode == 32 || errorCode == 33;
            }

            return false;
        }
    }
}
