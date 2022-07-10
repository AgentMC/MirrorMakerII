namespace WinMirrorMakerII
{
    partial class SessionWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BatchPanel = new System.Windows.Forms.Panel();
            this.BatchList = new System.Windows.Forms.ListBox();
            this.TotalProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SourceBox = new System.Windows.Forms.TextBox();
            this.SourceButon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DestinationBox = new System.Windows.Forms.TextBox();
            this.DestinationButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SessionProgress = new System.Windows.Forms.ProgressBar();
            this.MonitorTimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BackupLevelSelector = new System.Windows.Forms.NumericUpDown();
            this.folderLoader = new System.Windows.Forms.FolderBrowserDialog();
            this.ManualRun = new System.Windows.Forms.Button();
            this.ShowLog = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BatchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackupLevelSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // BatchPanel
            // 
            this.BatchPanel.Controls.Add(this.BatchList);
            this.BatchPanel.Controls.Add(this.TotalProgress);
            this.BatchPanel.Controls.Add(this.label1);
            this.BatchPanel.Controls.Add(this.label5);
            this.BatchPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BatchPanel.Location = new System.Drawing.Point(0, 217);
            this.BatchPanel.Name = "BatchPanel";
            this.BatchPanel.Size = new System.Drawing.Size(959, 178);
            this.BatchPanel.TabIndex = 0;
            // 
            // BatchList
            // 
            this.BatchList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BatchList.FormattingEnabled = true;
            this.BatchList.ItemHeight = 15;
            this.BatchList.Location = new System.Drawing.Point(12, 27);
            this.BatchList.Name = "BatchList";
            this.BatchList.Size = new System.Drawing.Size(935, 94);
            this.BatchList.TabIndex = 1;
            // 
            // TotalProgress
            // 
            this.TotalProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalProgress.Location = new System.Drawing.Point(12, 144);
            this.TotalProgress.Name = "TotalProgress";
            this.TotalProgress.Size = new System.Drawing.Size(935, 23);
            this.TotalProgress.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operations scheduled:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total progress:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Source:";
            // 
            // SourceBox
            // 
            this.SourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceBox.Location = new System.Drawing.Point(12, 27);
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.ReadOnly = true;
            this.SourceBox.Size = new System.Drawing.Size(736, 23);
            this.SourceBox.TabIndex = 2;
            // 
            // SourceButon
            // 
            this.SourceButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceButon.Location = new System.Drawing.Point(754, 26);
            this.SourceButon.Name = "SourceButon";
            this.SourceButon.Size = new System.Drawing.Size(111, 23);
            this.SourceButon.TabIndex = 3;
            this.SourceButon.Text = "Load source";
            this.SourceButon.UseVisualStyleBackColor = true;
            this.SourceButon.Click += new System.EventHandler(this.PathLoad);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Destination:";
            // 
            // DestinationBox
            // 
            this.DestinationBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationBox.Location = new System.Drawing.Point(12, 71);
            this.DestinationBox.Name = "DestinationBox";
            this.DestinationBox.ReadOnly = true;
            this.DestinationBox.Size = new System.Drawing.Size(736, 23);
            this.DestinationBox.TabIndex = 2;
            // 
            // DestinationButton
            // 
            this.DestinationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationButton.Location = new System.Drawing.Point(754, 70);
            this.DestinationButton.Name = "DestinationButton";
            this.DestinationButton.Size = new System.Drawing.Size(111, 23);
            this.DestinationButton.TabIndex = 3;
            this.DestinationButton.Text = "Load destination";
            this.DestinationButton.UseVisualStyleBackColor = true;
            this.DestinationButton.Click += new System.EventHandler(this.PathLoad);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Operation progress:";
            // 
            // SessionProgress
            // 
            this.SessionProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SessionProgress.Location = new System.Drawing.Point(12, 144);
            this.SessionProgress.Name = "SessionProgress";
            this.SessionProgress.Size = new System.Drawing.Size(935, 23);
            this.SessionProgress.TabIndex = 5;
            // 
            // MonitorTimer
            // 
            this.MonitorTimer.Interval = 16;
            this.MonitorTimer.Tick += new System.EventHandler(this.MonitorTimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Status:";
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Status.AutoEllipsis = true;
            this.Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Status.Location = new System.Drawing.Point(12, 186);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(935, 23);
            this.Status.TabIndex = 6;
            this.Status.Text = "Ready";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(871, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Backup level:";
            // 
            // BackupLevelSelector
            // 
            this.BackupLevelSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupLevelSelector.Location = new System.Drawing.Point(871, 45);
            this.BackupLevelSelector.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.BackupLevelSelector.Name = "BackupLevelSelector";
            this.BackupLevelSelector.Size = new System.Drawing.Size(76, 23);
            this.BackupLevelSelector.TabIndex = 7;
            // 
            // ManualRun
            // 
            this.ManualRun.Enabled = false;
            this.ManualRun.Location = new System.Drawing.Point(12, 100);
            this.ManualRun.Name = "ManualRun";
            this.ManualRun.Size = new System.Drawing.Size(435, 23);
            this.ManualRun.TabIndex = 8;
            this.ManualRun.Text = "Run";
            this.ManualRun.UseVisualStyleBackColor = true;
            this.ManualRun.Click += new System.EventHandler(this.GuiRun);
            // 
            // ShowLog
            // 
            this.ShowLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowLog.Location = new System.Drawing.Point(841, 100);
            this.ShowLog.Name = "ShowLog";
            this.ShowLog.Size = new System.Drawing.Size(106, 23);
            this.ShowLog.TabIndex = 9;
            this.ShowLog.Text = "Read Log...";
            this.ShowLog.UseVisualStyleBackColor = true;
            this.ShowLog.Click += new System.EventHandler(this.ShowLog_Click);
            // 
            // Cancel
            // 
            this.Cancel.Enabled = false;
            this.Cancel.Location = new System.Drawing.Point(453, 100);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(382, 23);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // SessionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 395);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.ShowLog);
            this.Controls.Add(this.ManualRun);
            this.Controls.Add(this.BackupLevelSelector);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.SessionProgress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DestinationButton);
            this.Controls.Add(this.SourceButon);
            this.Controls.Add(this.DestinationBox);
            this.Controls.Add(this.SourceBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BatchPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SessionWindow";
            this.Text = "Mirror Maker II";
            this.BatchPanel.ResumeLayout(false);
            this.BatchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackupLevelSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel BatchPanel;
        private ListBox BatchList;
        private Label label1;
        private Label label2;
        private TextBox SourceBox;
        private Button SourceButon;
        private Label label3;
        private TextBox DestinationBox;
        private Button DestinationButton;
        private Label label4;
        private ProgressBar SessionProgress;
        private Label label5;
        private ProgressBar TotalProgress;
        private System.Windows.Forms.Timer MonitorTimer;
        private Label label6;
        private Label Status;
        private Label label8;
        private NumericUpDown BackupLevelSelector;
        private FolderBrowserDialog folderLoader;
        private Button ManualRun;
        private Button ShowLog;
        private Button Cancel;
    }
}