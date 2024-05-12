using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Model;

namespace TorrentChecker
{
    public partial class TabContent : UserControl
    {
        readonly List<BaseDefinition> _definitions;

        public TabContent()
        {
            var secrets = File.ReadAllLines("secrets.txt");

            var secretsDict = secrets.Select(x => x.Split(new[]{"{040a6830-9315-4e00-9c5f-1eb9ad825a00}"}, StringSplitOptions.None)).ToDictionary(x => x[0], x => x[1]);

            _definitions = new List<BaseDefinition> {
                new RutorDefinition(secretsDict["Rutor"]),
                new RutrackerDefinition(secretsDict["Rutracker"]),
                new KinozalDefinition(secretsDict["Kinozal"]),
                new NnmDefinition(secretsDict["Nnm"])
            };

            InitializeComponent();
        }

        public string SearchText
        {
            get => searchTextBox.Text;
            set => searchTextBox.Text = value;
        }

        public DateTime SearchDate
        {
            get => searchDateTimePicker.Value;
            set => searchDateTimePicker.Value = value;
        }

        public EventHandler<TextChangedEventArgs> OnSearchStarted;
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1) return;
            System.Diagnostics.Process.Start(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            if ((ModifierKeys & Keys.Control) != 0) Focus(); 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) StartSearch();
        }

        public void StartSearch()
        {
            OnSearchStarted?.Invoke(this, new TextChangedEventArgs { Text = searchTextBox.Text });

            iTorrentBindingSource.DataSource = _definitions.SelectMany(x => x.Search(searchTextBox.Text ?? "", false))
                .Where(x => x.Date >= searchDateTimePicker.Value).OrderByDescending(x => x.Date).ToList();
        }
    }
}
