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

        public QuestionForm() {
            InitializeComponent();
        }

        private void QuestionForm_Load(object sender, EventArgs e) {

        }

        private void QuestionForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }
    }
}
