namespace QueApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.registerNewClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showClassResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerNewClassToolStripMenuItem,
            this.startClassToolStripMenuItem,
            this.showClassResultsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 92);
            // 
            // registerNewClassToolStripMenuItem
            // 
            this.registerNewClassToolStripMenuItem.Name = "registerNewClassToolStripMenuItem";
            this.registerNewClassToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.registerNewClassToolStripMenuItem.Text = "Register New Class...";
            this.registerNewClassToolStripMenuItem.Click += new System.EventHandler(this.registerNewClassToolStripMenuItem_Click);
            // 
            // startClassToolStripMenuItem
            // 
            this.startClassToolStripMenuItem.Name = "startClassToolStripMenuItem";
            this.startClassToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.startClassToolStripMenuItem.Text = "Start Class";
            // 
            // showClassResultsToolStripMenuItem
            // 
            this.showClassResultsToolStripMenuItem.Name = "showClassResultsToolStripMenuItem";
            this.showClassResultsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.showClassResultsToolStripMenuItem.Text = "Show Class Results";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 283);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showClassResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerNewClassToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

