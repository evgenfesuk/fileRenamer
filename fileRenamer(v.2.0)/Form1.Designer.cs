namespace fileRenamer_v._2._0_
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
            this.cmbx = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReName = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // cmbx
            // 
            this.cmbx.FormattingEnabled = true;
            this.cmbx.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbx.Items.AddRange(new object[] {
            "*.jpg",
            "*.bmp",
            "*.tiff",
            "*.gif",
            "*.cr2"});
            this.cmbx.Location = new System.Drawing.Point(74, 12);
            this.cmbx.Name = "cmbx";
            this.cmbx.Size = new System.Drawing.Size(77, 21);
            this.cmbx.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Choose folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReName
            // 
            this.btnReName.Enabled = false;
            this.btnReName.Location = new System.Drawing.Point(266, 12);
            this.btnReName.Name = "btnReName";
            this.btnReName.Size = new System.Drawing.Size(75, 23);
            this.btnReName.TabIndex = 2;
            this.btnReName.Text = "Rename";
            this.btnReName.UseVisualStyleBackColor = true;
            this.btnReName.Click += new System.EventHandler(this.btnReName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File format";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 42);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(328, 15);
            this.progressBar1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 65);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbx);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Renamer v2.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

