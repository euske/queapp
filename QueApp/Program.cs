using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace QueApp {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string path = "URI=file:queapp.db";
            using (SQLiteConnection conn = new SQLiteConnection(path)) {
                conn.Open();
                Database database = new Database(conn);
                Application.Run(new Form1(database));
                conn.Close();
            }
        }
    }
}
