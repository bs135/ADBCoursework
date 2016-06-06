using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OODBDemo
{
    public partial class FormMain : Form
    {
        private Kiemtraquyen kq = new Kiemtraquyen();

        private void Quanly_Load(object sender, EventArgs e)
        {
            FormDangnhap frmDangNhap = new FormDangnhap();
            frmDangNhap.ShowDialog();
            if (!frmDangNhap.loginSuccess)
            {
                this.Close();
            }

            lblUser.Text = "Xin chào " + FormDangnhap.loginUsename;
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void sinhvien_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "sinhvien", "module") == true)
            {
                FormSinhVien sv = new FormSinhVien();
                sv.Show();
            }
            else MessageBox.Show("Bạn không có quyền");

        }

        private void phanquyen_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "phanquyen", "module") == true)
           {
                FormPhanQuyen gq = new FormPhanQuyen();
                gq.Show();
            }
            else MessageBox.Show("Bạn không có quyền");
        }

        private void giaovien_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "giaovien", "module") == true)
            {
                FormGiaoVien sv = new FormGiaoVien();
                sv.Show();
            }
            else MessageBox.Show("Bạn không có quyền");

        }

        private void diem_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "diemsinhvien", "module") == true)
            {
                FormDiem sv = new FormDiem();
                sv.Show();
            }
            else MessageBox.Show("Bạn không có quyền");

        }

        private void monhoc_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "monhoc", "module") == true)
            {
                FormMonHoc sv = new FormMonHoc();
                sv.Show();
            }
            else MessageBox.Show("Bạn không có quyền");

        }

        private void lophoc_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "lop", "module") == true)
            {
                FormLopHoc sv = new FormLopHoc();
                sv.Show();
            }
            else MessageBox.Show("Bạn không có quyền");

        }

        private void khoa_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "khoa", "module") == true)
            {
                FormKhoa khoa = new FormKhoa();
                khoa.Show();
            }
            else MessageBox.Show("Bạn không có quyền");

        }


    }
}
