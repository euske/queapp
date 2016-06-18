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

        public ResultForm() {
            InitializeComponent();
            this.alive = true;
        }

        private void ResultForm_Load(object sender, EventArgs e) {
            
        }

        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = this.alive;
            this.Hide();
        }
    }
}
