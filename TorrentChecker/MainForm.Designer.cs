namespace TorrentChecker
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstTabPage = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.iTorrentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.tabContent1 = new TorrentChecker.TabContent();
            this.menuStrip1.SuspendLayout();
            this.firstTabPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTorrentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1077, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDriveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectDriveToolStripMenuItem
            // 
            this.selectDriveToolStripMenuItem.Name = "selectDriveToolStripMenuItem";
            this.selectDriveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.selectDriveToolStripMenuItem.Text = "Select drive";
            this.selectDriveToolStripMenuItem.Click += new System.EventHandler(this.selectDriveToolStripMenuItem_Click);
            // 
            // firstTabPage
            // 
            this.firstTabPage.Controls.Add(this.tabContent1);
            this.firstTabPage.Location = new System.Drawing.Point(4, 22);
            this.firstTabPage.Name = "firstTabPage";
            this.firstTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.firstTabPage.Size = new System.Drawing.Size(1045, 554);
            this.firstTabPage.TabIndex = 0;
            this.firstTabPage.Text = "New";
            this.firstTabPage.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.firstTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1053, 580);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
            // 
            // iTorrentBindingSource
            // 
            this.iTorrentBindingSource.DataSource = typeof(Model.ITorrent);
            // 
            // searchDateTimePicker
            // 
            this.searchDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.searchDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.searchDateTimePicker.Location = new System.Drawing.Point(946, 27);
            this.searchDateTimePicker.Name = "searchDateTimePicker";
            this.searchDateTimePicker.Size = new System.Drawing.Size(112, 29);
            this.searchDateTimePicker.TabIndex = 7;
            this.searchDateTimePicker.Value = new System.DateTime(2018, 9, 22, 20, 48, 26, 0);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.searchTextBox.Location = new System.Drawing.Point(12, 27);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.ReadOnly = true;
            this.searchTextBox.Size = new System.Drawing.Size(928, 29);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            // 
            // tabContent1
            // 
            this.tabContent1.AutoSize = true;
            this.tabContent1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabContent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContent1.Location = new System.Drawing.Point(3, 3);
            this.tabContent1.Name = "tabContent1";
            this.tabContent1.SearchDate = new System.DateTime(2018, 9, 22, 20, 48, 26, 0);
            this.tabContent1.SearchText = "";
            this.tabContent1.Size = new System.Drawing.Size(1039, 548);
            this.tabContent1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 654);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchDateTimePicker);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Torrent Checker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.firstTabPage.ResumeLayout(false);
            this.firstTabPage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iTorrentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource iTorrentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDriveToolStripMenuItem;
        private System.Windows.Forms.TabPage firstTabPage;
        private System.Windows.Forms.TabControl tabControl1;
        private TabContent tabContent1;
        private System.Windows.Forms.DateTimePicker searchDateTimePicker;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}

