//  Program.cs
//
using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace QueApp {

    /// <summary>
    ///   エントリーポイントを定義する。
    /// </summary>
    static class Program {
	
        /// <summary>
        ///   アプリケーションの起動時に呼ばれる。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // SQLite への接続を初期化する。
            string path = "URI=file:queapp.db";
            try {
                using (SQLiteConnection conn = new SQLiteConnection(path)) {
                    conn.Open();
                    Database database = new Database(conn);
                    // アプリケーションを開始する。
                    Application.Run(new Form1(database));
                    conn.Close();
                }
            } catch (SQLiteException e) {
                // SQLite に接続できなければ致命的なエラーとして即終了する。
                MessageBox.Show(
                    "Cannot connect to SQLite: "+e,
                    "Fatal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
