using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filework
{
    public partial class MainForm : Form
    {
        Engine engine;
        Tray tray;

        public MainForm()
        {
            InitializeComponent();
            this.CreateHandle();
            engine = new Engine(this);
            tray = new Tray(this, engine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            engine.Dispose();
            tray.Dispose();
            base.Dispose(disposing);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(this.Width, this.Height);
            this.Icon = Properties.Resources.app_r0;
            for (int i = 0; i < engine.settings.CommandCount; i++ )
            {
                rulesGrid.Rows.Add(
                    engine.settings.GetRuleType(i),
                    engine.settings.GetRuleCmdFile(i),
                    engine.settings.GetRuleCmdArgs(i));
            }
            cbPause.Checked = engine.settings.Pause;
            nudInterval.Value = engine.settings.Interval;

            if (engine.settings.isAlphabetic)
            {
                raAlphabetic.Checked = true;
            }
            else if (engine.settings.isSmallFirst)
            {
                raSmallFirst.Checked = true;
            }
            else
            {
                raLargeFirst.Checked = true;
            }
            tbInput.Text = engine.settings.DirInput;
            tbOutput.Text = engine.settings.DirOutput;
            tbWork.Text = engine.settings.DirWork;
            tbDone.Text = engine.settings.DirDone;

            engine.OnEngineUpdate += engine_OnEngineUpdate;

            UpdateButtonState();
            ResizeGrid();
            engine_OnEngineUpdate();
        }

        void engine_OnEngineUpdate()
        {
            tmrUpdateTime.Enabled = (engine.State != Engine.EngineStates.Paused);
            UpdateStatus();
        }

        void UpdateStatus()
        {
            lblStatus.Text = engine.GetStatus();
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            using(RuleEditForm r = new RuleEditForm())
            {
                r.ShowDialog();
                if(r.Good)
                {
                    rulesGrid.Rows.Add(r.Type, r.CmdFile, r.CmdArgs);
                    engine.settings.AddRule(r.Type, r.CmdFile, r.CmdArgs);
                    UpdateButtonState();
                    ResizeGrid();
                }
            }
        }

        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            if (rulesGrid.SelectedRows.Count == 0) return;
            engine.settings.RemoveRule(rulesGrid.SelectedRows[0].Index);
            rulesGrid.Rows.Remove(rulesGrid.SelectedRows[0]);
            UpdateButtonState();
            ResizeGrid();
        }

        void EditRule()
        {
            if (rulesGrid.SelectedRows.Count == 0) return;
            int idx = rulesGrid.SelectedRows[0].Index;
            using (RuleEditForm r = new RuleEditForm(
                    engine.settings.GetRuleType(idx),
                    engine.settings.GetRuleCmdFile(idx),
                    engine.settings.GetRuleCmdArgs(idx)))
            {
                r.ShowDialog();
                if (r.Good)
                {
                    rulesGrid.SelectedRows[0].SetValues(r.Type, r.CmdFile, r.CmdArgs);
                    engine.settings.SetRuleType(idx, r.Type);
                    engine.settings.SetRuleCmdFile(idx, r.CmdFile);
                    engine.settings.SetRuleCmdArgs(idx, r.CmdArgs);
                    ResizeGrid();
                }
            }   
        }

        private void btnEditRule_Click(object sender, EventArgs e)
        {
            EditRule();
        }

        void UpdateButtonState()
        {
            btnEditRule.Enabled = (rulesGrid.Rows.Count > 0);
            btnRemoveRule.Enabled = (rulesGrid.Rows.Count > 0);
        }

        private void rulesGrid_DoubleClick(object sender, EventArgs e)
        {
            EditRule();
        }

        void ResizeGrid()
        {
            rulesGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            rulesGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            rulesGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            int width = rulesGrid.Columns[0].Width + rulesGrid.Columns[1].Width + rulesGrid.Columns[2].Width;
            if (width < rulesGrid.Width) rulesGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void rulesGrid_Resize(object sender, EventArgs e)
        {
            ResizeGrid();
        }

        void ChoseFolder(TextBox tb, string Name)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Выберите папку " + Name + ":";
            fbd.ShowNewFolderButton = true;
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb.Text = fbd.SelectedPath;
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            ChoseFolder(tbInput, "Input");
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            ChoseFolder(tbOutput, "Output");
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            ChoseFolder(tbWork, "Work");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            ChoseFolder(tbDone, "Done");
        }
        
        void CheckFolder(TextBox tb)
        {
            if(Directory.Exists(tb.Text))
            {
                tb.BackColor = SystemColors.Window;
            }
            else
            {
                tb.BackColor = Color.LightPink;
                cbPause.Checked = true;
            }
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            engine.settings.DirInput = tbInput.Text;
            CheckFolder(tbInput);
        }

        private void tbOutput_TextChanged(object sender, EventArgs e)
        {
            engine.settings.DirOutput = tbOutput.Text;
            CheckFolder(tbOutput);
        }

        private void tbWork_TextChanged(object sender, EventArgs e)
        {
            engine.settings.DirWork = tbWork.Text;
            CheckFolder(tbWork);
        }

        private void tbDone_TextChanged(object sender, EventArgs e)
        {
            engine.settings.DirDone = tbDone.Text;
            CheckFolder(tbDone);
        }

        void UpdateSortOrder()
        {
            engine.settings.ScanType =
                raAlphabetic.Checked ? Settings.ScanTypes.Alphabetic :
                raSmallFirst.Checked ? Settings.ScanTypes.SmallFirst :
                                       Settings.ScanTypes.LargeFirst;

        }

        private void raAlphabetic_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSortOrder();
        }

        private void raLargeFirst_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSortOrder();
        }

        private void raSmallFirst_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSortOrder();
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            engine.SetInterval((int)nudInterval.Value);
        }

        private void cbPause_CheckedChanged(object sender, EventArgs e)
        {
            engine.SetPause(cbPause.Checked);
            btnScanNow.Enabled = !cbPause.Checked;
        }

        private void btnScanNow_Click(object sender, EventArgs e)
        {
            engine.ScanNow();
        }

        private void tmrUpdateTime_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }

    }
}
