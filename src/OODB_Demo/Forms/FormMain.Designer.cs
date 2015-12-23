namespace OODBDemo
{
    partial class FormMain
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
            this.btnNhapTTVS = new System.Windows.Forms.Button();
            this.btnMonHoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNhapTTVS
            // 
            this.btnNhapTTVS.Location = new System.Drawing.Point(41, 34);
            this.btnNhapTTVS.Name = "btnNhapTTVS";
            this.btnNhapTTVS.Size = new System.Drawing.Size(174, 23);
            this.btnNhapTTVS.TabIndex = 0;
            this.btnNhapTTVS.Text = "Nhập thông tin sinh viên";
            this.btnNhapTTVS.UseVisualStyleBackColor = true;
            this.btnNhapTTVS.Click += new System.EventHandler(this.btnNhapTTVS_Click);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.Location = new System.Drawing.Point(41, 63);
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.Size = new System.Drawing.Size(174, 23);
            this.btnMonHoc.TabIndex = 1;
            this.btnMonHoc.Text = "Môn học";
            this.btnMonHoc.UseVisualStyleBackColor = true;
            this.btnMonHoc.Click += new System.EventHandler(this.btnMonHoc_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 290);
            this.Controls.Add(this.btnMonHoc);
            this.Controls.Add(this.btnNhapTTVS);
            this.Name = "FormMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNhapTTVS;
        private System.Windows.Forms.Button btnMonHoc;
    }
}