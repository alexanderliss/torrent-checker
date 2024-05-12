namespace TorrentChecker
{
    partial class TabContent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabContent));
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.captionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dateStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTorrentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTorrentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // searchDateTimePicker
            // 
            resources.ApplyResources(this.searchDateTimePicker, "searchDateTimePicker");
            this.searchDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.searchDateTimePicker.Name = "searchDateTimePicker";
            this.searchDateTimePicker.Value = new System.DateTime(2018, 9, 22, 20, 48, 26, 0);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.captionDataGridViewTextBoxColumn,
            this.Url,
            this.dateStringDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.iTorrentBindingSource;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // captionDataGridViewTextBoxColumn
            // 
            this.captionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.captionDataGridViewTextBoxColumn.DataPropertyName = "Caption";
            resources.ApplyResources(this.captionDataGridViewTextBoxColumn, "captionDataGridViewTextBoxColumn");
            this.captionDataGridViewTextBoxColumn.Name = "captionDataGridViewTextBoxColumn";
            this.captionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Url
            // 
            this.Url.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Url.DataPropertyName = "Url";
            this.Url.FillWeight = 150F;
            resources.ApplyResources(this.Url, "Url");
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            // 
            // dateStringDataGridViewTextBoxColumn
            // 
            this.dateStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateStringDataGridViewTextBoxColumn.DataPropertyName = "DateString";
            resources.ApplyResources(this.dateStringDataGridViewTextBoxColumn, "dateStringDataGridViewTextBoxColumn");
            this.dateStringDataGridViewTextBoxColumn.Name = "dateStringDataGridViewTextBoxColumn";
            this.dateStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iTorrentBindingSource
            // 
            this.iTorrentBindingSource.DataSource = typeof(Model.ITorrent);
            // 
            // TabContent
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchDateTimePicker);
            this.Name = "TabContent";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTorrentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DateTimePicker searchDateTimePicker;
        private System.Windows.Forms.BindingSource iTorrentBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn captionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateStringDataGridViewTextBoxColumn;
    }
}
