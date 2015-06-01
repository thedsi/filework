namespace filework
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.rulesGrid = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmdFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmdArgs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbPause = new System.Windows.Forms.CheckBox();
            this.groupSort = new System.Windows.Forms.GroupBox();
            this.raSmallFirst = new System.Windows.Forms.RadioButton();
            this.raLargeFirst = new System.Windows.Forms.RadioButton();
            this.raAlphabetic = new System.Windows.Forms.RadioButton();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.btnRemoveRule = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tbWork = new System.Windows.Forms.TextBox();
            this.tbDone = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnWork = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnEditRule = new System.Windows.Forms.Button();
            this.btnScanNow = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrUpdateTime = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rulesGrid)).BeginInit();
            this.groupSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Правила:";
            // 
            // rulesGrid
            // 
            this.rulesGrid.AllowUserToAddRows = false;
            this.rulesGrid.AllowUserToDeleteRows = false;
            this.rulesGrid.AllowUserToResizeRows = false;
            this.rulesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rulesGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.rulesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rulesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.CmdFile,
            this.CmdArgs});
            this.rulesGrid.Location = new System.Drawing.Point(16, 38);
            this.rulesGrid.MultiSelect = false;
            this.rulesGrid.Name = "rulesGrid";
            this.rulesGrid.ReadOnly = true;
            this.rulesGrid.RowHeadersVisible = false;
            this.rulesGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rulesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rulesGrid.Size = new System.Drawing.Size(568, 141);
            this.rulesGrid.TabIndex = 1;
            this.rulesGrid.DoubleClick += new System.EventHandler(this.rulesGrid_DoubleClick);
            this.rulesGrid.Resize += new System.EventHandler(this.rulesGrid_Resize);
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // CmdFile
            // 
            this.CmdFile.HeaderText = "Команда";
            this.CmdFile.Name = "CmdFile";
            this.CmdFile.ReadOnly = true;
            // 
            // CmdArgs
            // 
            this.CmdArgs.HeaderText = "Аргументы";
            this.CmdArgs.Name = "CmdArgs";
            this.CmdArgs.ReadOnly = true;
            // 
            // cbPause
            // 
            this.cbPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPause.AutoSize = true;
            this.cbPause.Location = new System.Drawing.Point(397, 320);
            this.cbPause.Name = "cbPause";
            this.cbPause.Size = new System.Drawing.Size(57, 17);
            this.cbPause.TabIndex = 17;
            this.cbPause.Text = "Пауза";
            this.cbPause.UseVisualStyleBackColor = true;
            this.cbPause.CheckedChanged += new System.EventHandler(this.cbPause_CheckedChanged);
            // 
            // groupSort
            // 
            this.groupSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupSort.Controls.Add(this.raSmallFirst);
            this.groupSort.Controls.Add(this.raLargeFirst);
            this.groupSort.Controls.Add(this.raAlphabetic);
            this.groupSort.Location = new System.Drawing.Point(12, 214);
            this.groupSort.Name = "groupSort";
            this.groupSort.Size = new System.Drawing.Size(187, 91);
            this.groupSort.TabIndex = 3;
            this.groupSort.TabStop = false;
            this.groupSort.Text = "Обработка";
            // 
            // raSmallFirst
            // 
            this.raSmallFirst.AutoSize = true;
            this.raSmallFirst.Location = new System.Drawing.Point(6, 65);
            this.raSmallFirst.Name = "raSmallFirst";
            this.raSmallFirst.Size = new System.Drawing.Size(163, 17);
            this.raSmallFirst.TabIndex = 7;
            this.raSmallFirst.TabStop = true;
            this.raSmallFirst.Text = "Сначала маленькие файлы";
            this.raSmallFirst.UseVisualStyleBackColor = true;
            this.raSmallFirst.CheckedChanged += new System.EventHandler(this.raSmallFirst_CheckedChanged);
            // 
            // raLargeFirst
            // 
            this.raLargeFirst.AutoSize = true;
            this.raLargeFirst.Location = new System.Drawing.Point(6, 42);
            this.raLargeFirst.Name = "raLargeFirst";
            this.raLargeFirst.Size = new System.Drawing.Size(151, 17);
            this.raLargeFirst.TabIndex = 6;
            this.raLargeFirst.TabStop = true;
            this.raLargeFirst.Text = "Сначала большие файлы";
            this.raLargeFirst.UseVisualStyleBackColor = true;
            this.raLargeFirst.CheckedChanged += new System.EventHandler(this.raLargeFirst_CheckedChanged);
            // 
            // raAlphabetic
            // 
            this.raAlphabetic.AutoSize = true;
            this.raAlphabetic.Location = new System.Drawing.Point(6, 19);
            this.raAlphabetic.Name = "raAlphabetic";
            this.raAlphabetic.Size = new System.Drawing.Size(143, 17);
            this.raAlphabetic.TabIndex = 5;
            this.raAlphabetic.TabStop = true;
            this.raAlphabetic.Text = "В алфавитном порядке";
            this.raAlphabetic.UseVisualStyleBackColor = true;
            this.raAlphabetic.CheckedChanged += new System.EventHandler(this.raAlphabetic_CheckedChanged);
            // 
            // nudInterval
            // 
            this.nudInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudInterval.Location = new System.Drawing.Point(282, 319);
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(71, 20);
            this.nudInterval.TabIndex = 8;
            this.nudInterval.ValueChanged += new System.EventHandler(this.nudInterval_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Интервал:";
            // 
            // btnAddRule
            // 
            this.btnAddRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRule.Location = new System.Drawing.Point(174, 185);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(123, 23);
            this.btnAddRule.TabIndex = 2;
            this.btnAddRule.Text = "Добавить правило...";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // btnRemoveRule
            // 
            this.btnRemoveRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRule.Location = new System.Drawing.Point(461, 185);
            this.btnRemoveRule.Name = "btnRemoveRule";
            this.btnRemoveRule.Size = new System.Drawing.Size(123, 23);
            this.btnRemoveRule.TabIndex = 4;
            this.btnRemoveRule.Text = "Удалить правило";
            this.btnRemoveRule.UseVisualStyleBackColor = true;
            this.btnRemoveRule.Click += new System.EventHandler(this.btnRemoveRule_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Папка Input:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Папка Output:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Папка Work:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Папка Done:";
            // 
            // tbInput
            // 
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInput.Location = new System.Drawing.Point(282, 216);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(272, 20);
            this.tbInput.TabIndex = 9;
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Location = new System.Drawing.Point(282, 242);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(272, 20);
            this.tbOutput.TabIndex = 11;
            this.tbOutput.TextChanged += new System.EventHandler(this.tbOutput_TextChanged);
            // 
            // tbWork
            // 
            this.tbWork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWork.Location = new System.Drawing.Point(282, 268);
            this.tbWork.Name = "tbWork";
            this.tbWork.Size = new System.Drawing.Size(272, 20);
            this.tbWork.TabIndex = 13;
            this.tbWork.TextChanged += new System.EventHandler(this.tbWork_TextChanged);
            // 
            // tbDone
            // 
            this.tbDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDone.Location = new System.Drawing.Point(281, 294);
            this.tbDone.Name = "tbDone";
            this.tbDone.Size = new System.Drawing.Size(273, 20);
            this.tbDone.TabIndex = 15;
            this.tbDone.TextChanged += new System.EventHandler(this.tbDone_TextChanged);
            // 
            // btnInput
            // 
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInput.Location = new System.Drawing.Point(554, 214);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(30, 23);
            this.btnInput.TabIndex = 10;
            this.btnInput.Text = "...";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutput.Location = new System.Drawing.Point(554, 240);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(30, 23);
            this.btnOutput.TabIndex = 12;
            this.btnOutput.Text = "...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnWork
            // 
            this.btnWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWork.Location = new System.Drawing.Point(554, 266);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(30, 23);
            this.btnWork.TabIndex = 14;
            this.btnWork.Text = "...";
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Location = new System.Drawing.Point(554, 292);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(30, 23);
            this.btnDone.TabIndex = 16;
            this.btnDone.Text = "...";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnEditRule
            // 
            this.btnEditRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditRule.Location = new System.Drawing.Point(303, 185);
            this.btnEditRule.Name = "btnEditRule";
            this.btnEditRule.Size = new System.Drawing.Size(152, 23);
            this.btnEditRule.TabIndex = 3;
            this.btnEditRule.Text = "Редактировать правило...";
            this.btnEditRule.UseVisualStyleBackColor = true;
            this.btnEditRule.Click += new System.EventHandler(this.btnEditRule_Click);
            // 
            // btnScanNow
            // 
            this.btnScanNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScanNow.Location = new System.Drawing.Point(12, 311);
            this.btnScanNow.Name = "btnScanNow";
            this.btnScanNow.Size = new System.Drawing.Size(187, 40);
            this.btnScanNow.TabIndex = 18;
            this.btnScanNow.Text = "Сканировать сейчас";
            this.btnScanNow.UseVisualStyleBackColor = true;
            this.btnScanNow.Click += new System.EventHandler(this.btnScanNow_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 354);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(596, 22);
            this.statusStrip.TabIndex = 19;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 17);
            this.lblStatus.Text = "Status Label";
            // 
            // tmrUpdateTime
            // 
            this.tmrUpdateTime.Interval = 900;
            this.tmrUpdateTime.Tick += new System.EventHandler(this.tmrUpdateTime_Tick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "сек";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 376);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnScanNow);
            this.Controls.Add(this.btnEditRule);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnWork);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.tbDone);
            this.Controls.Add(this.tbWork);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemoveRule);
            this.Controls.Add(this.btnAddRule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.groupSort);
            this.Controls.Add(this.cbPause);
            this.Controls.Add(this.rulesGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система обработки файлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rulesGrid)).EndInit();
            this.groupSort.ResumeLayout(false);
            this.groupSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView rulesGrid;
        private System.Windows.Forms.CheckBox cbPause;
        private System.Windows.Forms.GroupBox groupSort;
        private System.Windows.Forms.RadioButton raSmallFirst;
        private System.Windows.Forms.RadioButton raLargeFirst;
        private System.Windows.Forms.RadioButton raAlphabetic;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.Button btnRemoveRule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.TextBox tbWork;
        private System.Windows.Forms.TextBox tbDone;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnWork;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnEditRule;
        private System.Windows.Forms.Button btnScanNow;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Timer tmrUpdateTime;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmdFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmdArgs;


    }
}

