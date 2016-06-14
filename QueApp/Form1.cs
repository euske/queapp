using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QueApp {
    public partial class Form1 : Form {
        private Database database;

        public Form1(Database database) {
            this.database = database;
            InitializeComponent();
            RefreshSubmenus();
        }

        [DllImport("User32.dll", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);
        private static IntPtr HWND_MESSAGE = new IntPtr(-3);

        protected override void CreateHandle() {
            base.CreateHandle();
            SetParent(Handle, HWND_MESSAGE);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void registerNewClassToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                RegisterNewClass(openFileDialog1.FileName);
            }
        }

        private void RefreshSubmenus() {
            startClassToolStripMenuItem.DropDownItems.Clear();
            showClassResultsToolStripMenuItem.DropDownItems.Clear();
            foreach (int classId in database.GetClassIds()) {
                string name = database.GetClassName(classId);
                ToolStripMenuItem startClassItem = new ToolStripMenuItem();
                startClassItem.Text = name;
                startClassItem.Click += startClassItem_Click;
                startClassItem.Tag = classId;
                startClassToolStripMenuItem.DropDownItems.Add(startClassItem);
                ToolStripMenuItem showClassResultsItem = new ToolStripMenuItem();
                showClassResultsItem.Text = name;
                showClassResultsItem.Click += showResultsItem_Click;
                showClassResultsItem.Tag = classId;
                showClassResultsToolStripMenuItem.DropDownItems.Add(showClassResultsItem);
            }
        }

        private void startClassItem_Click(object sender, EventArgs args) {
            if (sender is ToolStripMenuItem) {
                int classId = (int)(sender as ToolStripMenuItem).Tag;
                StartClass(classId);
            }
        }

        private void showResultsItem_Click(object sender, EventArgs args) {
            if (sender is ToolStripMenuItem) {
                int classId = (int)(sender as ToolStripMenuItem).Tag;
                ShowClassResults(classId);
            }
        }

        private void RegisterNewClass(string path) {
        }

        private void StartClass(int classId) {
        }

        private void ShowClassResults(int classId) {
        }
    }
}