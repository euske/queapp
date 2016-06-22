﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueApp {
    public partial class ResultForm : Form {

        public Database database;
        public bool alive;
        public int classId;

        public ResultForm() {
            InitializeComponent();
            this.alive = true;
        }

        public void SetClassId(int classId) {
            this.classId = classId;
            string className = this.database.GetClassName(this.classId);
            this.classNameLabel.Text = className;
            ShowQuestionResults();
        }

        public void ShowQuestionResults() {
            DataTable table = this.database.GetQuestionResultTable(this.classId);
            this.questionResultsTableGrid.DataSource = table;
        }

        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = this.alive;
            this.Hide();
        }

        private void resetResultsButton_Click(object sender, EventArgs e) {
            string text = "Reset all the results for class " + this.classNameLabel.Text + "?";
            if (MessageBox.Show(this, text, "Warning: Reset Results",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                    this.database.ResetResults(this.classId);
            }
        }

        private void exportResultsToCSVButton_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                this.database.ExportResultsToCSV(this.classId, saveFileDialog1.FileName);
            }
        }
    }
}
