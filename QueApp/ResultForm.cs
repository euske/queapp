using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueApp {
    public partial class ResultForm : Form {

        private Database database;
        private int classId;

        public ResultForm(Database database, int classId) {
            InitializeComponent();
            this.database = database;
            this.classId = classId;
        }

        public void ShowQuestionResults() {
            DataTable table = this.database.GetQuestionResultTable(this.classId);
            this.questionResultsTableGrid.DataSource = table;
        }

        private void ResultForm_Load(object sender, EventArgs e) {
            string className = this.database.GetClassName(this.classId);
            this.classNameLabel.Text = className;
            this.ShowQuestionResults();
        }

        private void resetResultsButton_Click(object sender, EventArgs e) {
            string text = "Reset all the results for class " + this.classNameLabel.Text + "?";
            if (MessageBox.Show(this, text, "Warning: Reset Results",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                this.database.ResetResults(this.classId);
                this.ShowQuestionResults();
            }
        }

        private void exportResultsToCSVButton_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                this.database.ExportResultsToCSV(this.classId, saveFileDialog1.FileName);
            }
        }
    }
}
