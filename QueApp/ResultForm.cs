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
    }
}
