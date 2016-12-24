//  Form1.cs
//
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QueApp {

    /// <summary>
    ///   アプリケーション全体にわたるUI処理をおこなう非表示のフォーム。
    /// </summary>
    public partial class Form1 : Form {

	// データベースへの接続。
        private Database database;
	// 質問フォーム。
        private QuestionForm questionForm;

	/// <summary>
	///   コンストラクタ。
	/// </summary>
        public Form1(Database database) {
            this.database = database;
            this.questionForm = new QuestionForm(database);
            InitializeComponent();
        }

	/// <summary>
	///   アプリケーションが終了するときに呼ばれる。
	/// </summary>
        protected override void CreateHandle() {
            base.CreateHandle();
            SetParent(Handle, HWND_MESSAGE);
        }

	/// <summary>
	///   アプリケーションの起動直後に呼ばれる。
	/// </summary>
        private void Form1_Load(object sender, EventArgs e) {
            UpdateSubmenus();
        }

	/// <summary>
	///   "Quit" メニュー項目が選択されたときに呼ばれる。
	/// </summary>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.questionForm.Close();
            Application.Exit();
        }

	/// <summary>
	///   "Register New Class..." メニュー項目が選択されたときに呼ばれる。
	/// </summary>
        private void registerNewClassToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                RegisterNewClass(openFileDialog1.FileName);
                UpdateSubmenus();
            }
        }

	/// <summary>
	///   "Start Class..." サブメニュー項目が選択されたときに呼ばれる。
	/// </summary>
        private void startClassItem_Click(object sender, EventArgs args) {
            if (sender is ToolStripMenuItem) {
                int classId = (int)(sender as ToolStripMenuItem).Tag;
                StartClass(classId);
            }
        }

	/// <summary>
	///   "Results >" サブメニュー項目が選択されたときに呼ばれる。
	/// </summary>
        private void showResultsItem_Click(object sender, EventArgs args) {
            if (sender is ToolStripMenuItem) {
                int classId = (int)(sender as ToolStripMenuItem).Tag;
                ShowClassResults(classId);
            }
        }

	/// <summary>
	///   指定されたCSVファイルを読み込み、新しい授業を登録する。
	/// </summary>
        private void RegisterNewClass(string path) {
            string[][] table = ParseCSVFile(path);
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

	// 授業を開始する。
        private void StartClass(int classId) {
            questionForm.SetClassId(classId);
            questionForm.Show();
            this.notifyIcon1.Text = questionForm.Text;
        }

	// これまでの授業の結果を表示する。
        private void ShowClassResults(int classId) {
            ResultForm resultForm = new ResultForm(database, classId);
            resultForm.Show();
        }

	/// <summary>
	///   SysTray のアイコンがクリックしたときに呼ばれる。
	/// </summary>
        private void notifyIcon1_Click(object sender, EventArgs e) {
            questionForm.Visible = !questionForm.Visible;
        }

	/// <summary>
	///   登録されている授業一覧をサブメニューに表示する。
	/// </summary>
        private void UpdateSubmenus() {
	    // 更新するサブメニューは 2つある。
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

	// Win32関数: SetParent
        [DllImport("User32.dll", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);
        private static IntPtr HWND_MESSAGE = new IntPtr(-3);

	/// <summary>
	///   CSVファイルを解析し、文字列の配列の配列として返す。
	/// </summary>
        private static string[][] ParseCSVFile(string path) {
            List<string[]> rows = new List<string[]>();
            using (StreamReader reader = new StreamReader(path)) {
                while (true) {
                    string line = reader.ReadLine();
                    if (line == null) break;
                    List<string> cols = new List<string>();
                    int colstart = 0;
                    for (int i = 0; i < line.Length; i++) {
                        char c = line[i];
                        if (c == ',') {
                            string value = line.Substring(colstart, i - colstart);
                            cols.Add(value);
                            colstart = i + 1;
                        }
                    }
                    cols.Add(line.Substring(colstart));
                    rows.Add(cols.ToArray());
                }
            }
            return rows.ToArray();
        }
    }
}
