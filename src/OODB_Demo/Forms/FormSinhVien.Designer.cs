namespace OODBDemo
{
    partial class FormSinhVien
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nhapsvexcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.masvt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.Button();
            this.lophoc = new System.Windows.Forms.ComboBox();
            this.khoa = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bacdaotao = new System.Windows.Forms.ComboBox();
            this.cmnd = new System.Windows.Forms.TextBox();
            this.khoasv = new System.Windows.Forms.ComboBox();
            this.dinhdangngay = new System.Windows.Forms.Label();
            this.ngaysinh = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.khoahoc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.masv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gioitinh = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dienthoai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Tensv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.malopd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bacdaotaod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoahocd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khoad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmndd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaysinhd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioitinhd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dienthoaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.luu = new System.Windows.Forms.Button();
            this.them = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.xoasv = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Nhập";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(712, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý  Thông Tin Sinh Viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nhapsvexcel
            // 
            this.nhapsvexcel.Location = new System.Drawing.Point(420, 9);
            this.nhapsvexcel.Name = "nhapsvexcel";
            this.nhapsvexcel.Size = new System.Drawing.Size(104, 23);
            this.nhapsvexcel.TabIndex = 3;
            this.nhapsvexcel.Text = "Nhập từ EXCEL";
            this.nhapsvexcel.UseVisualStyleBackColor = true;
            this.nhapsvexcel.Click += new System.EventHandler(this.nhapsvexcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.masvt);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tim);
            this.groupBox1.Controls.Add(this.lophoc);
            this.groupBox1.Controls.Add(this.khoa);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 50);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm Sinh Viên";
            // 
            // masvt
            // 
            this.masvt.Location = new System.Drawing.Point(268, 17);
            this.masvt.Margin = new System.Windows.Forms.Padding(2);
            this.masvt.Name = "masvt";
            this.masvt.Size = new System.Drawing.Size(121, 20);
            this.masvt.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(198, 20);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Mã Sinh Viên";
            // 
            // tim
            // 
            this.tim.Location = new System.Drawing.Point(617, 16);
            this.tim.Margin = new System.Windows.Forms.Padding(2);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(56, 22);
            this.tim.TabIndex = 12;
            this.tim.Text = "Tìm";
            this.tim.UseVisualStyleBackColor = true;
            this.tim.Click += new System.EventHandler(this.tim_Click);
            // 
            // lophoc
            // 
            this.lophoc.FormattingEnabled = true;
            this.lophoc.Location = new System.Drawing.Point(473, 17);
            this.lophoc.Name = "lophoc";
            this.lophoc.Size = new System.Drawing.Size(121, 21);
            this.lophoc.TabIndex = 11;
            this.lophoc.SelectedIndexChanged += new System.EventHandler(this.lophoc_SelectedIndexChanged);
            // 
            // khoa
            // 
            this.khoa.FormattingEnabled = true;
            this.khoa.Location = new System.Drawing.Point(42, 17);
            this.khoa.Name = "khoa";
            this.khoa.Size = new System.Drawing.Size(121, 21);
            this.khoa.TabIndex = 10;
            this.khoa.SelectedValueChanged += new System.EventHandler(this.khoa_SelectedValueChanged_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Lớp Học";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Khoa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbLop);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.monthCalendar1);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.bacdaotao);
            this.groupBox2.Controls.Add(this.cmnd);
            this.groupBox2.Controls.Add(this.khoasv);
            this.groupBox2.Controls.Add(this.dinhdangngay);
            this.groupBox2.Controls.Add(this.ngaysinh);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.khoahoc);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.diachi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.masv);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.gioitinh);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dienthoai);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Tensv);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 172);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // cmbLop
            // 
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(315, 57);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(99, 21);
            this.cmbLop.TabIndex = 52;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(634, 102);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(10, 13);
            this.label22.TabIndex = 51;
            this.label22.Text = "!";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(634, 63);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(10, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "!";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(200, 102);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(10, 13);
            this.label20.TabIndex = 49;
            this.label20.Text = "!";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(418, 137);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(10, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "!";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(205, -2);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 41;
            this.monthCalendar1.TodayDate = new System.DateTime(2015, 12, 4, 0, 0, 0, 0);
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.MouseLeave += new System.EventHandler(this.monthCalendar1_MouseLeave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(419, 97);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(10, 13);
            this.label18.TabIndex = 47;
            this.label18.Text = "!";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(419, 62);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(10, 13);
            this.label17.TabIndex = 46;
            this.label17.Text = "!";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(202, 61);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "!";
            // 
            // bacdaotao
            // 
            this.bacdaotao.FormattingEnabled = true;
            this.bacdaotao.Items.AddRange(new object[] {
            "Cao Đẳng",
            "Trung Cấp"});
            this.bacdaotao.Location = new System.Drawing.Point(315, 131);
            this.bacdaotao.Margin = new System.Windows.Forms.Padding(2);
            this.bacdaotao.Name = "bacdaotao";
            this.bacdaotao.Size = new System.Drawing.Size(100, 21);
            this.bacdaotao.TabIndex = 44;
            this.bacdaotao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bacdaotao_KeyPress);
            // 
            // cmnd
            // 
            this.cmnd.Location = new System.Drawing.Point(526, 98);
            this.cmnd.Margin = new System.Windows.Forms.Padding(2);
            this.cmnd.Name = "cmnd";
            this.cmnd.Size = new System.Drawing.Size(104, 20);
            this.cmnd.TabIndex = 43;
            this.cmnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmnd_KeyPress);
            // 
            // khoasv
            // 
            this.khoasv.FormattingEnabled = true;
            this.khoasv.Location = new System.Drawing.Point(526, 57);
            this.khoasv.Name = "khoasv";
            this.khoasv.Size = new System.Drawing.Size(104, 21);
            this.khoasv.TabIndex = 15;
            this.khoasv.SelectedValueChanged += new System.EventHandler(this.khoasv_SelectedValueChanged);
            this.khoasv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.khoasv_KeyPress);
            // 
            // dinhdangngay
            // 
            this.dinhdangngay.AutoSize = true;
            this.dinhdangngay.Location = new System.Drawing.Point(30, 119);
            this.dinhdangngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dinhdangngay.Name = "dinhdangngay";
            this.dinhdangngay.Size = new System.Drawing.Size(281, 13);
            this.dinhdangngay.TabIndex = 42;
            this.dinhdangngay.Text = "định dạng ngày đúng ngay/thang/nam ví dụ 12/02/2015";
            // 
            // ngaysinh
            // 
            this.ngaysinh.Location = new System.Drawing.Point(99, 98);
            this.ngaysinh.Margin = new System.Windows.Forms.Padding(2);
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(98, 20);
            this.ngaysinh.TabIndex = 40;
            this.ngaysinh.Click += new System.EventHandler(this.ngaysinh_Click);
            this.ngaysinh.TextChanged += new System.EventHandler(this.ngaysinh_TextChanged);
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(448, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Cmnd";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(448, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Khoa";
            // 
            // khoahoc
            // 
            this.khoahoc.Location = new System.Drawing.Point(526, 19);
            this.khoahoc.Name = "khoahoc";
            this.khoahoc.ReadOnly = true;
            this.khoahoc.Size = new System.Drawing.Size(104, 20);
            this.khoahoc.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(448, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Khóa học";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Bậc đào tạo";
            // 
            // diachi
            // 
            this.diachi.Location = new System.Drawing.Point(99, 133);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(100, 20);
            this.diachi.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Địa chỉ";
            // 
            // masv
            // 
            this.masv.Location = new System.Drawing.Point(99, 20);
            this.masv.Margin = new System.Windows.Forms.Padding(2);
            this.masv.Name = "masv";
            this.masv.ReadOnly = true;
            this.masv.Size = new System.Drawing.Size(100, 20);
            this.masv.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Điện thoại";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Mã sinh viên";
            // 
            // gioitinh
            // 
            this.gioitinh.FormattingEnabled = true;
            this.gioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.gioitinh.Location = new System.Drawing.Point(315, 93);
            this.gioitinh.Name = "gioitinh";
            this.gioitinh.Size = new System.Drawing.Size(100, 21);
            this.gioitinh.TabIndex = 29;
            this.gioitinh.TextChanged += new System.EventHandler(this.ngaysinh_TextChanged);
            this.gioitinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gioitinh_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Mã lớp";
            // 
            // dienthoai
            // 
            this.dienthoai.Location = new System.Drawing.Point(315, 23);
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Size = new System.Drawing.Size(100, 20);
            this.dienthoai.TabIndex = 27;
            this.dienthoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dienthoai_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Giới tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Ngày sinh";
            // 
            // Tensv
            // 
            this.Tensv.Location = new System.Drawing.Point(98, 57);
            this.Tensv.Name = "Tensv";
            this.Tensv.Size = new System.Drawing.Size(100, 20);
            this.Tensv.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Họ tên sinh viên";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(712, 185);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma,
            this.hoten,
            this.malopd,
            this.bacdaotaod,
            this.Khoahocd,
            this.khoad,
            this.cmndd,
            this.ngaysinhd,
            this.gioitinhd,
            this.diachid,
            this.dienthoaid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(706, 166);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // ma
            // 
            this.ma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ma.DataPropertyName = "ma";
            this.ma.HeaderText = "Mã sinh viên";
            this.ma.Name = "ma";
            this.ma.Width = 120;
            // 
            // hoten
            // 
            this.hoten.DataPropertyName = "hoten";
            this.hoten.HeaderText = "Họ Tên";
            this.hoten.Name = "hoten";
            // 
            // malopd
            // 
            this.malopd.DataPropertyName = "malop";
            this.malopd.HeaderText = "Mã lớp";
            this.malopd.Name = "malopd";
            // 
            // bacdaotaod
            // 
            this.bacdaotaod.DataPropertyName = "bacdaotao";
            this.bacdaotaod.HeaderText = "Bậc đào tạo";
            this.bacdaotaod.Name = "bacdaotaod";
            // 
            // Khoahocd
            // 
            this.Khoahocd.DataPropertyName = "khoahoc";
            this.Khoahocd.HeaderText = "Khóa học";
            this.Khoahocd.Name = "Khoahocd";
            // 
            // khoad
            // 
            this.khoad.DataPropertyName = "khoa";
            this.khoad.HeaderText = "Khoa";
            this.khoad.Name = "khoad";
            // 
            // cmndd
            // 
            this.cmndd.DataPropertyName = "cmnd";
            this.cmndd.HeaderText = "Cmnd";
            this.cmndd.Name = "cmndd";
            // 
            // ngaysinhd
            // 
            this.ngaysinhd.DataPropertyName = "ngaysinh";
            this.ngaysinhd.HeaderText = "Ngày sinh";
            this.ngaysinhd.Name = "ngaysinhd";
            // 
            // gioitinhd
            // 
            this.gioitinhd.DataPropertyName = "gioitinh";
            this.gioitinhd.HeaderText = "Giới tính";
            this.gioitinhd.Name = "gioitinhd";
            // 
            // diachid
            // 
            this.diachid.DataPropertyName = "diachi";
            this.diachid.HeaderText = "Địa chỉ";
            this.diachid.Name = "diachid";
            // 
            // dienthoaid
            // 
            this.dienthoaid.DataPropertyName = "dienthoai";
            this.dienthoaid.HeaderText = "Điện thoại";
            this.dienthoaid.Name = "dienthoaid";
            // 
            // luu
            // 
            this.luu.Location = new System.Drawing.Point(102, 9);
            this.luu.Margin = new System.Windows.Forms.Padding(2);
            this.luu.Name = "luu";
            this.luu.Size = new System.Drawing.Size(84, 23);
            this.luu.TabIndex = 21;
            this.luu.Text = "Sửa";
            this.luu.UseVisualStyleBackColor = true;
            this.luu.Click += new System.EventHandler(this.luu_Click);
            // 
            // them
            // 
            this.them.Location = new System.Drawing.Point(10, 9);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(87, 23);
            this.them.TabIndex = 22;
            this.them.Text = "Thêm";
            this.them.UseVisualStyleBackColor = true;
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // xoasv
            // 
            this.xoasv.Location = new System.Drawing.Point(190, 9);
            this.xoasv.Margin = new System.Windows.Forms.Padding(2);
            this.xoasv.Name = "xoasv";
            this.xoasv.Size = new System.Drawing.Size(92, 23);
            this.xoasv.TabIndex = 24;
            this.xoasv.Text = "Xóa";
            this.xoasv.UseVisualStyleBackColor = true;
            this.xoasv.Click += new System.EventHandler(this.xoasv_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(531, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 22);
            this.button2.TabIndex = 26;
            this.button2.Text = "Xuất ra file Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(297, 10);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 27;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Visible = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.them);
            this.panel1.Controls.Add(this.btnClearAll);
            this.panel1.Controls.Add(this.nhapsvexcel);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.luu);
            this.panel1.Controls.Add(this.xoasv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 43);
            this.panel1.TabIndex = 28;
            // 
            // FormSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 473);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "FormSinhVien";
            this.Text = "Nhapttsv";
            this.Load += new System.EventHandler(this.Nhapttsv_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nhapsvexcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox lophoc;
        private System.Windows.Forms.ComboBox khoa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox gioitinh;
        private System.Windows.Forms.TextBox dienthoai;
        private System.Windows.Forms.TextBox diachi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tensv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button tim;
        private System.Windows.Forms.Button luu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox khoahoc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox ngaysinh;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label dinhdangngay;
        private System.Windows.Forms.TextBox masvt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox masv;
        private System.Windows.Forms.Button xoasv;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox khoasv;
        private System.Windows.Forms.TextBox cmnd;
        private System.Windows.Forms.ComboBox bacdaotao;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn malopd;
        private System.Windows.Forms.DataGridViewTextBoxColumn bacdaotaod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Khoahocd;
        private System.Windows.Forms.DataGridViewTextBoxColumn khoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmndd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaysinhd;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioitinhd;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dienthoaid;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Panel panel1;
       
    }
}

