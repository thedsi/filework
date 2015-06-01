using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filework
{
    public partial class RuleEditForm : Form
    {
        public bool Good { get; private set; }

        public string CmdFile  { get { return tbCmdFile.Text; } set { tbCmdFile.Text = value; } }
        public string CmdArgs  { get { return tbCmdArgs.Text; } set { tbCmdArgs.Text = value; } }
        public string Type     { get { return tbType.Text;    } set { tbType.Text = value;    } }

        public RuleEditForm()
        {
            InitializeComponent();
            CmdArgs = Settings.defaultCmdLine;
            this.Text = "Новое правило";
        }

        public RuleEditForm(string type, string cmdFile, string cmdArgs) : this()
        {
            Type = type;
            CmdFile = cmdFile;
            CmdArgs = cmdArgs;
            this.Text = "Редактировать правило";
        }

        private void RuleEditForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.app_r0;
            this.MaximumSize = new Size(int.MaxValue, this.Size.Height);
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            Good = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Исполняемый файл (*.exe;*.cmd;*.bat)|*.exe;*.cmd;*.bat|Все файлы (*.*)|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                CmdFile = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Type.Length == 0 || CmdFile.Length == 0)
            {
                MessageBox.Show("Не все строки были заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Good = true;
                Close();
            }
        }



      
    }
}
