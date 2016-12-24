//  -*- tab-width: 4 -*-
//  QuestionForm.cs
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
	///   質問を表示するフォーム。
	/// </summary>
	public partial class QuestionForm : Form {

		// データベースへの接続。
		private Database database;
		// フォームが閉じようとしていれば真。
		private bool alive;
		// 現在実行中の授業ID (-1: 無効)。
		private int currentClassId;
		// 現在質問中の生徒ID (-1: 無効)。
		private int currentStudentId;

		/// <summary>
		///   コンストラクタ。
		/// </summary>
		public QuestionForm(Database database) {
			InitializeComponent();
			this.database = database;
			this.alive = true;
			this.currentClassId = -1;
			this.currentStudentId = -1;
		}

		/// <summary>
		///   指定されたIDの授業を開始する。
		/// </summary>
		public void SetClassId(int classId) {
			this.currentClassId = classId;
			// 授業名をタイトルとして表示する。
			string className = this.database.GetClassName(this.currentClassId);
			this.Text = className;
			// 最初の生徒を表示。
			ShowNextStudent();
		}

		/// <summary>
		///   次にあてるべき生徒名を表示する。
		/// </summary>
		public void ShowNextStudent() {
			if (0 <= this.currentClassId) {
				this.currentStudentId = this.database.GetNextStudentId(this.currentClassId);
				if (0 <= this.currentStudentId) {
					string studentName = this.database.GetStudentName(this.currentStudentId);
					if (studentName != null) {
						int nrecords = this.database.GetNumberOfClassRecords(this.currentClassId);
						this.studentNameLabel.Text = nrecords + ": " + studentName;
					}
				}
			}
			this.questionTextBox.Text = "";
		}

		/// <summary>
		///   フォームを閉じる。
		/// </summary>
		public new void Close() {
			this.alive = false;
			base.Close();
		}

		/// <summary>
		///   フォームの「×」ボタンが押されたときに呼ばれる。
		/// </summary>
		private void QuestionForm_FormClosing(object sender, FormClosingEventArgs e) {
			// Close() が呼ばれない限り、本当には Close() せず
			// ただ Hide() するだけ。
			e.Cancel = this.alive;
			this.Hide();
		}

		/// <summary>
		///   「再読み込み」ボタンが押されたときに呼ばれる。
		/// </summary>
		private void reloadButton_Click(object sender, EventArgs e) {
			ShowNextStudent();
		}

		/// <summary>
		///   「○」ボタンが押されたときに呼ばれる。
		/// </summary>
		private void answerOKButton_Click(object sender, EventArgs e) {
			StoreQuestionResult(1);
		}

		/// <summary>
		///   「×」ボタンが押されたときに呼ばれる。
		/// </summary>
		private void answerNGButton_Click(object sender, EventArgs e) {
			StoreQuestionResult(0);
		}

		/// <summary>
		///   現在の質問と結果をデータベースに記録する。
		/// </summary>
		private void StoreQuestionResult(int answerScore) {
			if (0 <= this.currentStudentId) {
				this.database.StoreResult(this.currentClassId,
										  this.currentStudentId, this.questionTextBox.Text,
										  answerScore);
			}
			ShowNextStudent();
		}
			
		/// <summary>
		///   キーボードショートカットの実行。
		/// </summary>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			switch (keyData) {
			case (Keys.Alt | Keys.T):
				StoreQuestionResult(1);
				return true;
			case (Keys.Alt | Keys.F):
				StoreQuestionResult(0);
				return true;
			case (Keys.Alt | Keys.R):
			case Keys.F5:
			case Keys.Escape:
				ShowNextStudent();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}

}
