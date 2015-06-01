using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bNewInstance;
            Mutex m = new Mutex(true, "{4BE8AC90-73A2-4897-89A8-5819781861BC}", out bNewInstance);
            if(!bNewInstance)
            {
                MessageBox.Show("Программа уже запущена");
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm f = new MainForm();
            Application.Run();
        }
    }
}
