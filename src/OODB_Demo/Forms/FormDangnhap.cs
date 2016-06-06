using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using LinqToExcel;
using System.Data;
using System.IO;
using OfficeOpenXml;
using OODBDemo.DBAccess;
using OODBDemo.Entities;
using OODBDemo.Utilities;
using System.Globalization;

namespace OODBDemo
{
    public partial class FormDangnhap : Form
    {
        DBConnect dbConnect = new DBConnect();

        public static string loginUsename = "";
        public bool loginSuccess = false;

        public FormDangnhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Decode mahoa = new Decode();
            string uname = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (!string.IsNullOrEmpty(uname) && !string.IsNullOrEmpty(pass))
                try
                {
                    dbConnect.Open();

                    User user = (from User p in dbConnect.db
                                 where p.Username == uname
                                 select p).SingleOrDefault();

                    if (user != null && user.password == mahoa.Encrypt(pass, "ahung_dhung_hai_huu", null))
                    {
                        loginUsename = uname;
                        loginSuccess = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    }
                }
                finally
                {
                    dbConnect.Close();
                }
            else
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập và mật khẩu");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(null, null);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(null, null);
            }
        }


    }
}
