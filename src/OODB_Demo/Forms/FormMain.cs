using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OODBDemo.DBAccess;

namespace OODBDemo
{
    public partial class FormMain : Form
    {
        //private Nhapttsv frmNhapTTVS = new Nhapttsv();
        private FormMonHoc frmMonHoc = new FormMonHoc();
        private FormGiaoVien frmGiaoVien = new FormGiaoVien();
        private FormKhoa frmKhoa = new FormKhoa();

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnNhapTTVS_Click(object sender, EventArgs e)
        {
            //frmNhapTTVS.ShowDialog();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            frmMonHoc.ShowDialog();
        }

        private void btnGiaoVien_Click(object sender, EventArgs e)
        {
            frmGiaoVien.ShowDialog();
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            frmKhoa.ShowDialog();
        }
    }
}
