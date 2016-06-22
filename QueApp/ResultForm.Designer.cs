namespace QueApp {
    partial class ResultForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.exportResultsToCSVButton = new System.Windows.Forms.Button();
            this.resetResultsButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.classNameLabel = new System.Windows.Forms.Label();
            this.questionResultsTableGrid = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultsTableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.exportResultsToCSVButton);
            this.flowLayoutPanel1.Controls.Add(this.resetResultsButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 230);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // exportResultsToCSVButton
            // 
            this.exportResultsToCSVButton.Location = new System.Drawing.Point(206, 3);
            this.exportResultsToCSVButton.Name = "exportResultsToCSVButton";
            this.exportResultsToCSVButton.Size = new System.Drawing.Size(75, 25);
            this.exportResultsToCSVButton.TabIndex = 0;
            this.exportResultsToCSVButton.Text = "Export...";
            this.exportResultsToCSVButton.UseVisualStyleBackColor = true;
            this.exportResultsToCSVButton.Click += new System.EventHandler(this.exportResultsToCSVButton_Click);
            // 
            // resetResultsButton
            // 
            this.resetResultsButton.Location = new System.Drawing.Point(125, 3);
            this.resetResultsButton.Name = "resetResultsButton";
            this.resetResultsButton.Size = new System.Drawing.Size(75, 25);
            this.resetResultsButton.TabIndex = 1;
            this.resetResultsButton.Text = "Reset...";
            this.resetResultsButton.UseVisualStyleBackColor = true;
            this.resetResultsButton.Click += new System.EventHandler(this.resetResultsButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.classNameLabel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(284, 40);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // classNameLabel
            // 
            this.classNameLabel.AutoSize = true;
            this.classNameLabel.Location = new System.Drawing.Point(3, 0);
            this.classNameLabel.Name = "classNameLabel";
            this.classNameLabel.Size = new System.Drawing.Size(59, 13);
            this.classNameLabel.TabIndex = 0;
            this.classNameLabel.Text = "className";
            // 
            // questionResultsTableGrid
            // 
            this.questionResultsTableGrid.AllowUserToAddRows = false;
            this.questionResultsTableGrid.AllowUserToDeleteRows = false;
            this.questionResultsTableGrid.AllowUserToOrderColumns = true;
            this.questionResultsTableGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questionResultsTableGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.questionResultsTableGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.questionResultsTableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionResultsTableGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionResultsTableGrid.Location = new System.Drawing.Point(0, 40);
            this.questionResultsTableGrid.Name = "questionResultsTableGrid";
            this.questionResultsTableGrid.ReadOnly = true;
            this.questionResultsTableGrid.Size = new System.Drawing.Size(284, 190);
            this.questionResultsTableGrid.TabIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.questionResultsTableGrid);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultsTableGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button exportResultsToCSVButton;
        private System.Windows.Forms.Button resetResultsButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label classNameLabel;
        private System.Windows.Forms.DataGridView questionResultsTableGrid;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}