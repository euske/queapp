using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QueApp {
    public partial class Form1 : Form {

        private Database database;
        private QuestionForm questionForm;
        private ResultForm resultForm;

        public Form1(Database database) {
            this.database = database;
            this.questionForm = new QuestionForm();
            this.questionForm.database = database;
            this.resultForm = new ResultForm();
            this.resultForm.database = database;
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
            this.questionForm.alive = false;
            this.resultForm.alive = false;
            Application.Exit();
        }

        private void registerNewClassToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                RegisterNewClass(openFileDialog1.FileName);
                RefreshSubmenus();
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
            string[][] table = Database.ParseCSVFile(path);
            string className = table[0][0];
            List<string> studentNames = new List<string>();
            for (int i = 1; i < table.Length; i++) {
                string[] row = table[i];
                if (0 < row.Length) {
                    studentNames.Add(row[0]);
                }
            }
            database.RegisterNewClass(className, studentNames.ToArray());
        }

        private void StartClass(int classId) {
            questionForm.SetClassId(classId);
            questionForm.Show();
        }

        private void ShowClassResults(int classId) {
            resultForm.Show();
        }
    }
}