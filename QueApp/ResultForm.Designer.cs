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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.exportResultsToCSVButton = new System.Windows.Forms.Button();
            this.resetResultsButton = new System.Windows.Forms.Button();
            this.questionResultsTableGrid = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.classNameLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionResultsTableGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.exportResultsToCSVButton);
            this.flowLayoutPanel1.Controls.Add(this.resetResultsButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 252);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // exportResultsToCSVButton
            // 
            this.exportResultsToCSVButton.Location = new System.Drawing.Point(306, 3);
            this.exportResultsToCSVButton.Name = "exportResultsToCSVButton";
            this.exportResultsToCSVButton.Size = new System.Drawing.Size(75, 25);
            this.exportResultsToCSVButton.TabIndex = 0;
            this.exportResultsToCSVButton.Text = "Export...";
            this.exportResultsToCSVButton.UseVisualStyleBackColor = true;
            this.exportResultsToCSVButton.Click += new System.EventHandler(this.exportResultsToCSVButton_Click);
            // 
            // resetResultsButton
            // 
            this.resetResultsButton.Location = new System.Drawing.Point(225, 3);
            this.resetResultsButton.Name = "resetResultsButton";
            this.resetResultsButton.Size = new System.Drawing.Size(75, 25);
            this.resetResultsButton.TabIndex = 1;
            this.resetResultsButton.Text = "Reset...";
            this.resetResultsButton.UseVisualStyleBackColor = true;
            this.resetResultsButton.Click += new System.EventHandler(this.resetResultsButton_Click);
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
            this.questionResultsTableGrid.Location = new System.Drawing.Point(0, 34);
            this.questionResultsTableGrid.Name = "questionResultsTableGrid";
            this.questionResultsTableGrid.ReadOnly = true;
            this.questionResultsTableGrid.Size = new System.Drawing.Size(384, 218);
            this.questionResultsTableGrid.TabIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.classNameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 34);
            this.panel1.TabIndex = 3;
            // 
            // classNameLabel
            // 
            this.classNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.classNameLabel.Location = new System.Drawing.Point(0, 0);
            this.classNameLabel.Name = "classNameLabel";
            this.classNameLabel.Size = new System.Drawing.Size(384, 34);
            this.classNameLabel.TabIndex = 1;
            this.classNameLabel.Text = "className";
            this.classNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 283);
            this.Controls.Add(this.questionResultsTableGrid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionResultsTableGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button exportResultsToCSVButton;
        private System.Windows.Forms.Button resetResultsButton;
        private System.Windows.Forms.DataGridView questionResultsTableGrid;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label classNameLabel;
    }
}