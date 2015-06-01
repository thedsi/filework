using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace filework
{
    public class Settings
    {
        public static string defaultCmdLine = "\"%WORKDIR%\" \"%FILENAME%\" \"%OUTPUTDIR%\" \"%CLEANNAME%\"";

        public class TypeCmd
        {
            public string type;
            public string cmdfile;
            public string cmdargs;
        }

        public enum ScanTypes
        {
            Alphabetic,
            SmallFirst,
            LargeFirst
        }

        public string SettingsFilename { get; private set; }
        public bool Changed { get; private set; }

        //Сами настройки:
        string DirInput_;
        string DirOutput_;
        string DirWork_;
        string DirDone_;
        List<TypeCmd> Commands_;
        int Interval_;
        ScanTypes ScanType_;
        bool Pause_;

        void CheckChange<T>(ref T val, T newval)
        {
            if(Comparer<T>.Default.Compare(val, newval) != 0)
            {
                val = newval;
                Changed = true;
            }
        }

        public string    DirInput  { get { return DirInput_;  } set { CheckChange(ref DirInput_,  value); } }
        public string    DirOutput { get { return DirOutput_; } set { CheckChange(ref DirOutput_, value); } }
        public string    DirWork   { get { return DirWork_;   } set { CheckChange(ref DirWork_,   value); } }
        public string    DirDone   { get { return DirDone_;   } set { CheckChange(ref DirDone_,   value); } }
        public int       Interval  { get { return Interval_;  } set { CheckChange(ref Interval_,  value); } }
        public ScanTypes ScanType  { get { return ScanType_;  } set { CheckChange(ref ScanType_,  value); } }
        public bool      Pause     { get { return Pause_;     } set { CheckChange(ref Pause_,     value); } }

        //Rule manipulation:

        public void AddRule(string Type, string CmdFile, string CmdArgs)
        {
            Commands_.Add(new TypeCmd { type = Type, cmdfile = CmdFile, cmdargs = CmdArgs });
        }
        public void RemoveRule(int i)
        {
            Commands_.RemoveAt(i);
            Changed = true;
        }

        public string GetRuleCmdFile(string type)
        {
            var cmd = Commands_.FirstOrDefault(x => x.type == type);
            return cmd != null ? cmd.cmdfile : null;
        }
        public string GetRuleCmdFile(int index)
        {
            return Commands_.ElementAt(index).cmdfile;
        }
        public void SetRuleCmdFile(int index, string cmdfile)
        {
            CheckChange(ref Commands_.ElementAt(index).cmdfile, cmdfile);
        }


        public string GetRuleCmdArgs(string type)
        {
            var cmd = Commands_.FirstOrDefault(x => x.type == type);
            return cmd != null ? cmd.cmdargs : null;
        }
        public string GetRuleCmdArgs(int index)
        {
            return Commands_.ElementAt(index).cmdargs;
        }
        public void SetRuleCmdArgs(int index, string cmdargs)
        {
            CheckChange(ref Commands_.ElementAt(index).cmdargs, cmdargs);
        }


        public string GetRuleType(int index)
        {
            return Commands_.ElementAt(index).type;
        }
        public void SetRuleType(int index, string type)
        {
            CheckChange(ref Commands_.ElementAt(index).type, type);
        }


        public int CommandCount { get { return Commands_.Count; } }

        public bool isAlphabetic { get { return ScanType_ == ScanTypes.Alphabetic; } }
        public bool isSmallFirst { get { return ScanType_ == ScanTypes.SmallFirst; } }
        public bool isLargeFirst { get { return ScanType_ == ScanTypes.LargeFirst; } }

        void InitDefault()
        {
            string root = Path.GetDirectoryName(Application.ExecutablePath);
            DirInput_ = root + "\\Input";
            DirOutput_ = root + "\\Output";
            DirWork_ = root + "\\Work";
            DirDone_ = root + "\\Done";
            Pause_ = true;
            ScanType_ = ScanTypes.Alphabetic;
            Interval_ = 10;
            Commands_ = new List<TypeCmd>();
            AddRule("50p.mts", root + "\\MyCmd50p_mts.cmd", defaultCmdLine);
            Changed = true; // Default settings are explicitly marked as changed so that engine will save them
        }

        public void Save()
        {
            if (Changed) SaveAs(SettingsFilename);
        }

        public void SaveAs(string filename)
        {
            Func<string,string,XElement> CreateDirElement = (type, value) =>
            {
                XElement r = new XElement("Dir", value);
                r.SetAttributeValue("Type", type);
                return r;
            };
            XElement root = new XElement("Settings",
                CreateDirElement("Input",  DirInput_),
                CreateDirElement("Output", DirOutput_),
                CreateDirElement("Work",   DirWork_),
                CreateDirElement("Done",   DirDone_),
                new XElement("Paused", Pause_),
                new XElement("Interval", Interval_),
                new XElement("ScanType", ScanType_)
            );
            foreach(var rule in Commands_)
            {
                XElement xrule = new XElement("Command",
                    new XElement("CmdFile", rule.cmdfile),
                    new XElement("CmdArgs", rule.cmdargs));
                xrule.SetAttributeValue("Type", rule.type);
                root.Add(xrule);
            }
            root.Save(filename);
            SettingsFilename = filename;
            Changed = false;
        }

        public Settings(string filename)
        {
            try
            {
                InitDefault();
                Commands_ = new List<TypeCmd>();
                XElement root = XElement.Load(filename);
                var nodes = root.Nodes();
                foreach(XElement element in nodes)
                {
                    if(element.Name == "Dir")
                    {
                        string type = element.Attribute("Type").Value;
                        if      (type == "Input" ) DirInput_  = element.Value;
                        else if (type == "Output") DirOutput_ = element.Value;
                        else if (type == "Work"  ) DirWork_   = element.Value;
                        else if (type == "Done"  ) DirDone_   = element.Value;
                    }
                    else if (element.Name == "Paused")
                    {
                        Pause_ = bool.Parse(element.Value);
                    }
                    else if (element.Name == "Interval")
                    {
                        Interval_ = int.Parse(element.Value);
                    }
                    else if (element.Name == "ScanType")
                    {
                        ScanType_ = (ScanTypes)Enum.Parse(typeof(ScanTypes), element.Value);
                    }
                    else if (element.Name == "Command")
                    {
                        var nodes2 = element.Nodes();
                        string type = element.Attribute("Type").Value;
                        string cmdfile = ((XElement)nodes2.First(x => ((XElement)x).Name == "CmdFile")).Value;
                        string cmdargs = ((XElement)nodes2.First(x => ((XElement)x).Name == "CmdArgs")).Value;
                        Commands_.Add(new TypeCmd { type = type, cmdfile = cmdfile, cmdargs = cmdargs });
                    }
                }
                Changed = false;
            }
            catch
            {
                InitDefault();
            }
            SettingsFilename = filename;
        }
        
        public Settings()
        {
            InitDefault();
        }
    }
}
