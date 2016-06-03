using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QueApp
{
    public partial class Form1 : Form
    {
        private Database database;

        public Form1(Database database)
        {
            this.database = database;
            InitializeComponent();
        }

        [DllImport("User32.dll", EntryPoint="SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);
        private static IntPtr HWND_MESSAGE = new IntPtr(-3);

        protected override void CreateHandle()
        {
            base.CreateHandle();
            SetParent(Handle, HWND_MESSAGE);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
