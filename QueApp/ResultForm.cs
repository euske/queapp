//  ResultForm.cs
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueApp {

    /// <summary>
    ///   結果を表示するためのフォーム。
    /// </summary>
    public partial class ResultForm : Form {

	// データベースへの接続。
        private Database database;
	// 現在表示中の授業ID。
        private int classId;

	/// <summary>
	///   コンストラクタ。
	/// </summary>
        public ResultForm(Database database, int classId) {
            InitializeComponent();
            this.database = database;
            this.classId = classId;
        }

	/// <summary>
	///   質問結果を表示する。
	/// </summary>
        public void ShowQuestionResults() {
            DataTable table = this.database.GetQuestionResultTable(this.classId);
            this.questionResultsTableGrid.DataSource = table;
        }

	/// <summary>
	///   フォームが開かれるときに呼ばれる。
	/// </summary>
        private void ResultForm_Load(object sender, EventArgs e) {
            string className = this.database.GetClassName(this.classId);
            this.classNameLabel.Text = className;
            this.ShowQuestionResults();
	    this.database.RecordUpdated += Database_RecordUpdated;
        }

	/// <summary>
	///   質問結果が変化したときに呼ばれる。
	/// </summary>
	private void Database_RecordUpdated(object sender, ClassIdEventArgs e) {
	    if (e.classId == this.classId) {
		this.ShowQuestionResults();
	    }
	}

	/// <summary>
	///   「Reset Results...」ボタンがクリックされたときに呼ばれる。
	/// </summary>
        private void resetResultsButton_Click(object sender, EventArgs e) {
	    // 警告ダイアログを表示する。
            string text = "Reset all the results for class " + this.classNameLabel.Text + "?";
            if (MessageBox.Show(this, text, "Warning: Reset Results",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Warning) == DialogResult.OK) {
                this.database.ResetResults(this.classId);
            }
        }

	/// <summary>
	///   「Export Results...」ボタンがクリックされたときに呼ばれる。
	/// </summary>
        private void exportResultsToCSVButton_Click(object sender, EventArgs e) {
	    // 保存ダイアログを表示する。
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                this.database.ExportResultsToCSV(this.classId, saveFileDialog1.FileName);
            }
        }
    }
}
