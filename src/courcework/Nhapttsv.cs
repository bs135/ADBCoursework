using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o.Linq;
using LinqToExcel;
namespace courcework
{
    public partial class Nhapttsv : Form
    {
        public Nhapttsv()
        {
            InitializeComponent();
        }

        private void Nhapttsv_Load(object sender, EventArgs e)
        {
            try
            {
                ketnoicsdl.Opendb("D:\\oodb.db4o");
                IList<Sinhvien> result = (from Sinhvien p in ketnoicsdl.db
                                            //   where p.Ma.CompareTo(1)==0
                                               select p).ToList();
                dataGridView1.DataSource = result;
                
            }
            finally
            {
                 ketnoicsdl.db.Close();
            }

        }

        private void them_Click(object sender, EventArgs e)
        {
            masv.Text="";
            Tensv.Text="";
            ngaysinh.Text="";
            gioitinh.Text="";
            diachi.Text="";
            dienthoai.Text = "";
        }

        private void luu_Click(object sender, EventArgs e)
        {
            Sinhvien sv = new Sinhvien();
            sv.addsv( int.Parse(masv.Text),Tensv.Text,ngaysinh.Text,gioitinh.Text,diachi.Text,int.Parse(dienthoai.Text),
                malop.Text,bacdaotao.Text,int.Parse(khoahoc.Text),khoa.Text,nganhhoc.Text);
            
        }

        private void nhapsvexcel_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
          
            string pathToExcelFile = ""
             + @openFileDialog1.FileName;

            string sheetName = "Sheet1";

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var docexcel = from a in excelFile.Worksheet<Sinhvien>(sheetName) select a;

            foreach (var a in docexcel)
            {
                Sinhvien sv = new Sinhvien();
                sv.addsv(int.Parse(a.Ma.ToString()),a.Hoten,a.Ngaysinh,a.Gioitinh,a.Diachi,int.Parse(a.Dienthoai.ToString()),a.Malop,a.Bacdaotao,a.Khoahoc,a.Khoa,a.Nganhhoc);
            
            }
            
        }

        

     
    }
}
