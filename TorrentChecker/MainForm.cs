using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Model;

namespace TorrentChecker
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();

            searchDateTimePicker.Value = DateTime.Now;
        }
        
        private static void ProcessDirectoriesRecursive(List<string> files, string directory)
        {
            files.AddRange(Directory.GetFiles(directory, "*.tsearch"));
            var directories = Directory.GetDirectories(directory);
            foreach (var dir in directories)
                ProcessDirectoriesRecursive(files, dir);
        }

        private void selectDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var res = dialog.ShowDialog();
            if (res != DialogResult.OK) return;

            searchTextBox.Text = dialog.SelectedPath;
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            var dateFile = Directory.GetFiles(searchTextBox.Text, "*.tdate").FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(dateFile))
            {
                var dateNumbers =
                    (dateFile.Split(new[] {'\\'}, StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? "")
                    .Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries).Select(x=>
                    {
                        int.TryParse(x, out var value);
                        return value;
                    }).ToArray();
                searchDateTimePicker.Value = new DateTime(dateNumbers[2], dateNumbers[1], dateNumbers[0]);
            }
                

            var files = Directory.GetFiles(searchTextBox.Text, "*.tsearch").ToList();
            var directories = Directory.GetDirectories(searchTextBox.Text).Where(x => !x.Contains("RECYCLE.BIN") && !x.Contains("System Volume Information"));
            foreach (var directory in directories)
            {
                files.AddRange(Directory.GetFiles(directory, "*.tsearch"));
                ProcessDirectoriesRecursive(files, directory);
            }

            var searchKeys = files.Select(x => (x.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? ".")
                                               .Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? "")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x =>
                {
                    var tabPage = new TabPage("New");
                    var tab = new TabContent { Dock = DockStyle.Fill, SearchText = x, SearchDate = searchDateTimePicker.Value };
                    tabPage.Controls.Add(tab);
                    tab.OnSearchStarted += (o, args) => { tabPage.Text = args.Text; };
                    tab.StartSearch();
                    return tabPage;
                });

            tabControl1.TabPages.Clear();
            tabControl1.TabPages.AddRange(searchKeys.ToArray());
        }
    }
}
