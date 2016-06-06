namespace OODBDemo
{
    partial class FormGiaoVien
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvListData = new System.Windows.Forms.DataGridView();
            this.ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.cmbTrinhDo = new System.Windows.Forms.ComboBox();
            this.cmbGioiTinh = new System.Windows.Forms.ComboBox();
            this.dtimeNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtNangKhieu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuocTich = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListData)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(821, 30);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(821, 30);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Quản Lý Giáo Viên";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.grpSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 30);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(821, 59);
            this.pnlSearch.TabIndex = 1;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.txtKeyword);
            this.grpSearch.Controls.Add(this.label15);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(821, 59);
            this.grpSearch.TabIndex = 18;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Tìm Kiếm";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(59, 21);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(2);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(247, 20);
            this.txtKeyword.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 24);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Từ khóa";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(310, 20);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 22);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 230);
            this.panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvListData);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(821, 230);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách";
            // 
            // dgvListData
            // 
            this.dgvListData.AllowUserToAddRows = false;
            this.dgvListData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma});
            this.dgvListData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListData.Location = new System.Drawing.Point(3, 16);
            this.dgvListData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListData.Name = "dgvListData";
            this.dgvListData.ReadOnly = true;
            this.dgvListData.RowTemplate.Height = 24;
            this.dgvListData.Size = new System.Drawing.Size(815, 211);
            this.dgvListData.TabIndex = 0;
            this.dgvListData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListData_CellMouseClick);
            this.dgvListData.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListData_RowHeaderMouseClick);
            // 
            // ma
            // 
            this.ma.DataPropertyName = "ma";
            this.ma.HeaderText = "Mã";
            this.ma.Name = "ma";
            this.ma.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExportExcel);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnImportExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 476);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 47);
            this.panel2.TabIndex = 3;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(450, 11);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(120, 25);
            this.btnExportExcel.TabIndex = 33;
            this.btnExportExcel.Text = "Xuất ra Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(180, 11);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 25);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 25);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(96, 11);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 25);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(325, 11);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(120, 25);
            this.btnImportExcel.TabIndex = 27;
            this.btnImportExcel.Text = "Nhập từ Excel";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbKhoa);
            this.panel3.Controls.Add(this.cmbTrinhDo);
            this.panel3.Controls.Add(this.cmbGioiTinh);
            this.panel3.Controls.Add(this.dtimeNgaySinh);
            this.panel3.Controls.Add(this.txtNangKhieu);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtQuocTich);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtCMND);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtEmail);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtDienThoai);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtDiaChi);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtHoTen);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtMa);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 319);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(821, 157);
            this.panel3.TabIndex = 3;
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(563, 34);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(247, 21);
            this.cmbKhoa.TabIndex = 42;
            // 
            // cmbTrinhDo
            // 
            this.cmbTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrinhDo.FormattingEnabled = true;
            this.cmbTrinhDo.Location = new System.Drawing.Point(563, 58);
            this.cmbTrinhDo.Name = "cmbTrinhDo";
            this.cmbTrinhDo.Size = new System.Drawing.Size(247, 21);
            this.cmbTrinhDo.TabIndex = 41;
            // 
            // cmbGioiTinh
            // 
            this.cmbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGioiTinh.FormattingEnabled = true;
            this.cmbGioiTinh.Location = new System.Drawing.Point(96, 82);
            this.cmbGioiTinh.Name = "cmbGioiTinh";
            this.cmbGioiTinh.Size = new System.Drawing.Size(247, 21);
            this.cmbGioiTinh.TabIndex = 40;
            // 
            // dtimeNgaySinh
            // 
            this.dtimeNgaySinh.CustomFormat = "dd/MM/yyy";
            this.dtimeNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtimeNgaySinh.Location = new System.Drawing.Point(96, 59);
            this.dtimeNgaySinh.Name = "dtimeNgaySinh";
            this.dtimeNgaySinh.Size = new System.Drawing.Size(247, 20);
            this.dtimeNgaySinh.TabIndex = 39;
            // 
            // txtNangKhieu
            // 
            this.txtNangKhieu.Location = new System.Drawing.Point(563, 131);
            this.txtNangKhieu.Margin = new System.Windows.Forms.Padding(2);
            this.txtNangKhieu.Name = "txtNangKhieu";
            this.txtNangKhieu.Size = new System.Drawing.Size(247, 20);
            this.txtNangKhieu.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(475, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Năng khiếu";
            // 
            // txtQuocTich
            // 
            this.txtQuocTich.Location = new System.Drawing.Point(563, 107);
            this.txtQuocTich.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuocTich.Name = "txtQuocTich";
            this.txtQuocTich.Size = new System.Drawing.Size(247, 20);
            this.txtQuocTich.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(475, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Quốc tịch";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(563, 83);
            this.txtCMND.Margin = new System.Windows.Forms.Padding(2);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(247, 20);
            this.txtCMND.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(475, 86);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "CMND";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(475, 62);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Trình độ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 38);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Khoa";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(563, 11);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(247, 20);
            this.txtEmail.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(475, 14);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Email";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(96, 131);
            this.txtDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(247, 20);
            this.txtDienThoai.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Điện thoại";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(96, 107);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(247, 20);
            this.txtDiaChi.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ngày sinh";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(96, 35);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(247, 20);
            this.txtHoTen.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Họ tên";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(96, 11);
            this.txtMa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(247, 20);
            this.txtMa.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mã";
            // 
            // FormGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 523);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlTitle);
            this.Name = "FormGiaoVien";
            this.Text = "Quản lý giáo viên";
            this.Load += new System.EventHandler(this.frmMonHoc_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvListData;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma;
        private System.Windows.Forms.TextBox txtNangKhieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuocTich;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtimeNgaySinh;
        private System.Windows.Forms.ComboBox cmbGioiTinh;
        private System.Windows.Forms.ComboBox cmbTrinhDo;
        private System.Windows.Forms.ComboBox cmbKhoa;
    }
}