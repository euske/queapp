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

        private void RefreshSubmenus() {
            startClassToolStripMenuItem.DropDownItems.Clear();
            showResultsToolStripMenuItem.DropDownItems.Clear();
            foreach (int classId in database.GetClassIds()) {
                string name = database.GetClassName(classId);
                ToolStripMenuItem startClassItem = new ToolStripMenuItem();
                startClassItem.Text = name;
                startClassItem.Click += startClassItem_Click;
                startClassToolStripMenuItem.DropDownItems.Add(startClassItem);
                ToolStripMenuItem showResultsItem = new ToolStripMenuItem();
                showResultsItem.Text = name;
                showResultsItem.Click += showResultsItem_Click;
                showResultsToolStripMenuItem.DropDownItems.Add(showResultsItem);
            }
        }

        private void startClassItem_Click(object sender, EventArgs args) {
        }

        private void showResultsItem_Click(object sender, EventArgs args) {
        }

        private void registerNewClassToolStripMenuItem_Click(object sender, EventArgs e) {

        }
    }
}