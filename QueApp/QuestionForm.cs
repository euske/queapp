using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueApp {
    public partial class QuestionForm : Form {

        private Database database;
        private int classId;
        private int currentStudentId;
        private bool alive;

        public QuestionForm(Database database) {
            InitializeComponent();
            this.database = database;
            this.alive = true;
        }

        public void SetClassId(int classId) {
            this.classId = classId;
            string className = this.database.GetClassName(this.classId);
            this.Text = className;
            ShowNextStudent();
        }

        public void ShowNextStudent() {
            this.currentStudentId = this.database.GetNextStudentId(this.classId);
            if (0 <= this.currentStudentId) {
                string studentName = this.database.GetStudentName(this.currentStudentId);
                if (studentName != null) {
                    this.studentNameLabel.Text = studentName;
                }
            }
            this.questionTextBox.Text = "";
        }

        public void Close() {
            this.alive = false;
            base.Close();
        }

        private void QuestionForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = this.alive;
            this.Hide();
        }

        private void reloadButton_Click(object sender, EventArgs e) {
            ShowNextStudent();
        }

        private void answerOKButton_Click(object sender, EventArgs e) {
            if (0 <= this.currentStudentId) {
                this.database.StoreResult(this.currentStudentId, this.questionTextBox.Text, 1);
            }
            ShowNextStudent();
        }

        private void answerNGButton_Click(object sender, EventArgs e) {
            if (0 <= this.currentStudentId) {
                this.database.StoreResult(this.currentStudentId, this.questionTextBox.Text, 0);
            }
            ShowNextStudent();
        }
    }
}
