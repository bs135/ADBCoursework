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
            this.label1 = new System.Windows.Forms.Label();
            this.phanquyen = new System.Windows.Forms.Button();
            this.sinhvien = new System.Windows.Forms.Button();
            this.khoa = new System.Windows.Forms.Button();
            this.monhoc = new System.Windows.Forms.Button();
            this.lophoc = new System.Windows.Forms.Button();
            this.diem = new System.Windows.Forms.Button();
            this.giaovien = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(72, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý thông tin trường học";
            // 
            // phanquyen
            // 
            this.phanquyen.Image = global::OODBDemo.Properties.Resources.securityx48;
            this.phanquyen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.phanquyen.Location = new System.Drawing.Point(135, 324);
            this.phanquyen.Margin = new System.Windows.Forms.Padding(2);
            this.phanquyen.Name = "phanquyen";
            this.phanquyen.Size = new System.Drawing.Size(90, 75);
            this.phanquyen.TabIndex = 7;
            this.phanquyen.Text = "Phân quyền";
            this.phanquyen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.phanquyen.UseVisualStyleBackColor = true;
            this.phanquyen.Click += new System.EventHandler(this.phanquyen_Click);
            // 
            // sinhvien
            // 
            this.sinhvien.Image = global::OODBDemo.Properties.Resources.studentx48;
            this.sinhvien.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sinhvien.Location = new System.Drawing.Point(205, 71);
            this.sinhvien.Margin = new System.Windows.Forms.Padding(2);
            this.sinhvien.Name = "sinhvien";
            this.sinhvien.Size = new System.Drawing.Size(90, 75);
            this.sinhvien.TabIndex = 6;
            this.sinhvien.Text = "Sinh viên";
            this.sinhvien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sinhvien.UseVisualStyleBackColor = true;
            this.sinhvien.Click += new System.EventHandler(this.sinhvien_Click);
            // 
            // khoa
            // 
            this.khoa.Image = global::OODBDemo.Properties.Resources.facultyx48;
            this.khoa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.khoa.Location = new System.Drawing.Point(205, 229);
            this.khoa.Margin = new System.Windows.Forms.Padding(2);
            this.khoa.Name = "khoa";
            this.khoa.Size = new System.Drawing.Size(90, 75);
            this.khoa.TabIndex = 5;
            this.khoa.Text = "Khoa";
            this.khoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.khoa.UseVisualStyleBackColor = true;
            this.khoa.Click += new System.EventHandler(this.khoa_Click);
            // 
            // monhoc
            // 
            this.monhoc.Image = global::OODBDemo.Properties.Resources.courcex48;
            this.monhoc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.monhoc.Location = new System.Drawing.Point(205, 150);
            this.monhoc.Margin = new System.Windows.Forms.Padding(2);
            this.monhoc.Name = "monhoc";
            this.monhoc.Size = new System.Drawing.Size(90, 75);
            this.monhoc.TabIndex = 4;
            this.monhoc.Text = "Môn học";
            this.monhoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.monhoc.UseVisualStyleBackColor = true;
            this.monhoc.Click += new System.EventHandler(this.monhoc_Click);
            // 
            // lophoc
            // 
            this.lophoc.Image = global::OODBDemo.Properties.Resources.classroomx48;
            this.lophoc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lophoc.Location = new System.Drawing.Point(68, 229);
            this.lophoc.Margin = new System.Windows.Forms.Padding(2);
            this.lophoc.Name = "lophoc";
            this.lophoc.Size = new System.Drawing.Size(90, 75);
            this.lophoc.TabIndex = 3;
            this.lophoc.Text = "Lớp học";
            this.lophoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lophoc.UseVisualStyleBackColor = true;
            this.lophoc.Click += new System.EventHandler(this.lophoc_Click);
            // 
            // diem
            // 
            this.diem.Image = global::OODBDemo.Properties.Resources.scorex48;
            this.diem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.diem.Location = new System.Drawing.Point(68, 150);
            this.diem.Margin = new System.Windows.Forms.Padding(2);
            this.diem.Name = "diem";
            this.diem.Size = new System.Drawing.Size(90, 75);
            this.diem.TabIndex = 2;
            this.diem.Text = "Điểm";
            this.diem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.diem.UseVisualStyleBackColor = true;
            this.diem.Click += new System.EventHandler(this.diem_Click);
            // 
            // giaovien
            // 
            this.giaovien.Image = global::OODBDemo.Properties.Resources.teacherx48;
            this.giaovien.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.giaovien.Location = new System.Drawing.Point(68, 71);
            this.giaovien.Margin = new System.Windows.Forms.Padding(2);
            this.giaovien.Name = "giaovien";
            this.giaovien.Size = new System.Drawing.Size(90, 75);
            this.giaovien.TabIndex = 1;
            this.giaovien.Text = "Giáo viên";
            this.giaovien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.giaovien.UseVisualStyleBackColor = true;
            this.giaovien.Click += new System.EventHandler(this.giaovien_Click);
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(2, 43);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(293, 21);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "user";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 429);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.phanquyen);
            this.Controls.Add(this.sinhvien);
            this.Controls.Add(this.khoa);
            this.Controls.Add(this.monhoc);
            this.Controls.Add(this.lophoc);
            this.Controls.Add(this.diem);
            this.Controls.Add(this.giaovien);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông tin trường học";
            this.Load += new System.EventHandler(this.Quanly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button giaovien;
        private System.Windows.Forms.Button diem;
        private System.Windows.Forms.Button lophoc;
        private System.Windows.Forms.Button monhoc;
        private System.Windows.Forms.Button khoa;
        private System.Windows.Forms.Button sinhvien;
        private System.Windows.Forms.Button phanquyen;
        private System.Windows.Forms.Label lblUser;
    }
}