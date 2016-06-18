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

        public Database database;
        public bool alive;
        public int classId;
        public int currentStudentId;

        public QuestionForm() {
            InitializeComponent();
            this.alive = true;
        }

        public void SetClassId(int classId) {
            this.classId = classId;
            string className = this.database.GetClassName(this.classId);
            this.classNameLabel.Text = className;
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

        private void QuestionForm_Load(object sender, EventArgs e) {

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
                this.database.StoreResult(this.currentStudentId, this.questionTextBox.Text, +1);
            }
            ShowNextStudent();
        }

        private void answerNGButton_Click(object sender, EventArgs e) {
            if (0 <= this.currentStudentId) {
                this.database.StoreResult(this.currentStudentId, this.questionTextBox.Text, -1);
            }
            ShowNextStudent();
        }
    }
}
