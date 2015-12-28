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
            this.btnGiaoVien = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNhapTTVS
            // 
            this.btnNhapTTVS.Location = new System.Drawing.Point(41, 34);
            this.btnNhapTTVS.Name = "btnNhapTTVS";
            this.btnNhapTTVS.Size = new System.Drawing.Size(174, 23);
            this.btnNhapTTVS.TabIndex = 0;
            this.btnNhapTTVS.Text = "Sinh viên";
            this.btnNhapTTVS.UseVisualStyleBackColor = true;
            this.btnNhapTTVS.Click += new System.EventHandler(this.btnNhapTTVS_Click);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.Location = new System.Drawing.Point(272, 34);
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.Size = new System.Drawing.Size(174, 23);
            this.btnMonHoc.TabIndex = 1;
            this.btnMonHoc.Text = "Môn học";
            this.btnMonHoc.UseVisualStyleBackColor = true;
            this.btnMonHoc.Click += new System.EventHandler(this.btnMonHoc_Click);
            // 
            // btnGiaoVien
            // 
            this.btnGiaoVien.Location = new System.Drawing.Point(272, 63);
            this.btnGiaoVien.Name = "btnGiaoVien";
            this.btnGiaoVien.Size = new System.Drawing.Size(174, 23);
            this.btnGiaoVien.TabIndex = 2;
            this.btnGiaoVien.Text = "Giáo viên";
            this.btnGiaoVien.UseVisualStyleBackColor = true;
            this.btnGiaoVien.Click += new System.EventHandler(this.btnGiaoVien_Click);
            // 
            // btnKhoa
            // 
            this.btnKhoa.Location = new System.Drawing.Point(272, 92);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(174, 23);
            this.btnKhoa.TabIndex = 3;
            this.btnKhoa.Text = "Khoa";
            this.btnKhoa.UseVisualStyleBackColor = true;
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 290);
            this.Controls.Add(this.btnKhoa);
            this.Controls.Add(this.btnGiaoVien);
            this.Controls.Add(this.btnMonHoc);
            this.Controls.Add(this.btnNhapTTVS);
            this.Name = "FormMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNhapTTVS;
        private System.Windows.Forms.Button btnMonHoc;
        private System.Windows.Forms.Button btnGiaoVien;
        private System.Windows.Forms.Button btnKhoa;
    }
}