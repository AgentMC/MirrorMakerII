namespace WinMirrorMakerII
{
    partial class LogParser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SessionsDropDown = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackupDirectoryDeleteList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BackupDirectoryCreateList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BackupDirectoryMoveList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BackupFileMoveList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.MirrorDirectoryCreateList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.MirrorFileDeleteList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.MirrorDirectoryDeleteList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.MirrorFileMoveList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.MirrorFileCopyList = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // SessionsDropDown
            // 
            this.SessionsDropDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.SessionsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SessionsDropDown.FormattingEnabled = true;
            this.SessionsDropDown.Location = new System.Drawing.Point(0, 0);
            this.SessionsDropDown.Name = "SessionsDropDown";
            this.SessionsDropDown.Size = new System.Drawing.Size(1333, 23);
            this.SessionsDropDown.TabIndex = 0;
            this.SessionsDropDown.SelectedIndexChanged += new System.EventHandler(this.SessionsDropDown_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 23);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1333, 913);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1333, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BackupDirectoryDeleteList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 144);
            this.panel1.TabIndex = 0;
            // 
            // BackupDirectoryDeleteList
            // 
            this.BackupDirectoryDeleteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackupDirectoryDeleteList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BackupDirectoryDeleteList.FormattingEnabled = true;
            this.BackupDirectoryDeleteList.ItemHeight = 15;
            this.BackupDirectoryDeleteList.Location = new System.Drawing.Point(0, 15);
            this.BackupDirectoryDeleteList.Name = "BackupDirectoryDeleteList";
            this.BackupDirectoryDeleteList.Size = new System.Drawing.Size(438, 129);
            this.BackupDirectoryDeleteList.TabIndex = 1;
            this.BackupDirectoryDeleteList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup folders deleted";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BackupDirectoryCreateList);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(447, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 144);
            this.panel2.TabIndex = 1;
            // 
            // BackupDirectoryCreateList
            // 
            this.BackupDirectoryCreateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackupDirectoryCreateList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BackupDirectoryCreateList.FormattingEnabled = true;
            this.BackupDirectoryCreateList.ItemHeight = 15;
            this.BackupDirectoryCreateList.Location = new System.Drawing.Point(0, 15);
            this.BackupDirectoryCreateList.Name = "BackupDirectoryCreateList";
            this.BackupDirectoryCreateList.Size = new System.Drawing.Size(438, 129);
            this.BackupDirectoryCreateList.TabIndex = 1;
            this.BackupDirectoryCreateList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Backup folders created";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BackupDirectoryMoveList);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(891, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(439, 144);
            this.panel3.TabIndex = 2;
            // 
            // BackupDirectoryMoveList
            // 
            this.BackupDirectoryMoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackupDirectoryMoveList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BackupDirectoryMoveList.FormattingEnabled = true;
            this.BackupDirectoryMoveList.ItemHeight = 15;
            this.BackupDirectoryMoveList.Location = new System.Drawing.Point(0, 15);
            this.BackupDirectoryMoveList.Name = "BackupDirectoryMoveList";
            this.BackupDirectoryMoveList.Size = new System.Drawing.Size(439, 129);
            this.BackupDirectoryMoveList.TabIndex = 1;
            this.BackupDirectoryMoveList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Backup folders moved";
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 3);
            this.panel4.Controls.Add(this.BackupFileMoveList);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 153);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1327, 144);
            this.panel4.TabIndex = 3;
            // 
            // BackupFileMoveList
            // 
            this.BackupFileMoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackupFileMoveList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BackupFileMoveList.FormattingEnabled = true;
            this.BackupFileMoveList.ItemHeight = 15;
            this.BackupFileMoveList.Location = new System.Drawing.Point(0, 15);
            this.BackupFileMoveList.Name = "BackupFileMoveList";
            this.BackupFileMoveList.Size = new System.Drawing.Size(1327, 129);
            this.BackupFileMoveList.TabIndex = 1;
            this.BackupFileMoveList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Backup files saved";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel10, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1333, 609);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.MirrorDirectoryCreateList);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(438, 196);
            this.panel5.TabIndex = 0;
            // 
            // MirrorDirectoryCreateList
            // 
            this.MirrorDirectoryCreateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MirrorDirectoryCreateList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MirrorDirectoryCreateList.FormattingEnabled = true;
            this.MirrorDirectoryCreateList.ItemHeight = 15;
            this.MirrorDirectoryCreateList.Location = new System.Drawing.Point(0, 15);
            this.MirrorDirectoryCreateList.Name = "MirrorDirectoryCreateList";
            this.MirrorDirectoryCreateList.Size = new System.Drawing.Size(438, 181);
            this.MirrorDirectoryCreateList.TabIndex = 1;
            this.MirrorDirectoryCreateList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Folders created";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.MirrorFileDeleteList);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(447, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(438, 196);
            this.panel6.TabIndex = 1;
            // 
            // MirrorFileDeleteList
            // 
            this.MirrorFileDeleteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MirrorFileDeleteList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MirrorFileDeleteList.FormattingEnabled = true;
            this.MirrorFileDeleteList.ItemHeight = 15;
            this.MirrorFileDeleteList.Location = new System.Drawing.Point(0, 15);
            this.MirrorFileDeleteList.Name = "MirrorFileDeleteList";
            this.MirrorFileDeleteList.Size = new System.Drawing.Size(438, 181);
            this.MirrorFileDeleteList.TabIndex = 1;
            this.MirrorFileDeleteList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Files deleted";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.MirrorDirectoryDeleteList);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(891, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(439, 196);
            this.panel7.TabIndex = 2;
            // 
            // MirrorDirectoryDeleteList
            // 
            this.MirrorDirectoryDeleteList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MirrorDirectoryDeleteList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MirrorDirectoryDeleteList.FormattingEnabled = true;
            this.MirrorDirectoryDeleteList.ItemHeight = 15;
            this.MirrorDirectoryDeleteList.Location = new System.Drawing.Point(0, 15);
            this.MirrorDirectoryDeleteList.Name = "MirrorDirectoryDeleteList";
            this.MirrorDirectoryDeleteList.Size = new System.Drawing.Size(439, 181);
            this.MirrorDirectoryDeleteList.TabIndex = 1;
            this.MirrorDirectoryDeleteList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Folders deleted";
            // 
            // panel8
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel8, 3);
            this.panel8.Controls.Add(this.MirrorFileMoveList);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 205);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1327, 196);
            this.panel8.TabIndex = 3;
            // 
            // MirrorFileMoveList
            // 
            this.MirrorFileMoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MirrorFileMoveList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MirrorFileMoveList.FormattingEnabled = true;
            this.MirrorFileMoveList.ItemHeight = 15;
            this.MirrorFileMoveList.Location = new System.Drawing.Point(0, 15);
            this.MirrorFileMoveList.Name = "MirrorFileMoveList";
            this.MirrorFileMoveList.Size = new System.Drawing.Size(1327, 181);
            this.MirrorFileMoveList.TabIndex = 1;
            this.MirrorFileMoveList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Files moved";
            // 
            // panel10
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel10, 3);
            this.panel10.Controls.Add(this.MirrorFileCopyList);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(3, 407);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1327, 199);
            this.panel10.TabIndex = 5;
            // 
            // MirrorFileCopyList
            // 
            this.MirrorFileCopyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MirrorFileCopyList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MirrorFileCopyList.FormattingEnabled = true;
            this.MirrorFileCopyList.ItemHeight = 15;
            this.MirrorFileCopyList.Location = new System.Drawing.Point(0, 15);
            this.MirrorFileCopyList.Name = "MirrorFileCopyList";
            this.MirrorFileCopyList.Size = new System.Drawing.Size(1327, 184);
            this.MirrorFileCopyList.TabIndex = 1;
            this.MirrorFileCopyList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Renderer);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "New files copied / were overwritten";
            // 
            // LogParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 936);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.SessionsDropDown);
            this.Name = "LogParser";
            this.Text = "MirrorMaker II Log Viewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox SessionsDropDown;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Label label3;
        private Panel panel4;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel2;
        private ListBox BackupDirectoryDeleteList;
        private ListBox BackupDirectoryCreateList;
        private ListBox BackupDirectoryMoveList;
        private ListBox BackupFileMoveList;
        private Panel panel5;
        private ListBox MirrorDirectoryCreateList;
        private Label label5;
        private Panel panel6;
        private ListBox MirrorFileDeleteList;
        private Label label6;
        private Panel panel7;
        private ListBox MirrorDirectoryDeleteList;
        private Label label7;
        private Panel panel8;
        private ListBox MirrorFileMoveList;
        private Label label8;
        private Panel panel10;
        private ListBox MirrorFileCopyList;
        private Label label9;
    }
}