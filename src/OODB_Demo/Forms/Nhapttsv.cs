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
using System.Globalization;
namespace OODBDemo
{
    public partial class Nhapttsv : Form
    {
        Checkinput ck = new Checkinput();
        public Nhapttsv()
        {
            InitializeComponent();

            monthCalendar1.Hide();

            //ExcelPackage package = new ExcelPackage();
        }
        private void Nhapttsv_Load(object sender, EventArgs e)
        {
            dinhdangngay.Visible = false;
            ngaysinh.Text = "01/01/1997";
            Khoa kh = new Khoa();
           for (int i = 0; i < kh.listkhoa().Count;i++)
            {
                khoa.Items.Add(new KeyValuePair<string, string> ( kh.listkhoa()[i].Tenkhoa, kh.listkhoa()[i].Makhoa ));
                khoasv.Items.Add(new KeyValuePair<string, string>(kh.listkhoa()[i].Tenkhoa, kh.listkhoa()[i].Makhoa));
            }
           khoa.DisplayMember = "Key";
           khoa.ValueMember = "Value";
           khoasv.DisplayMember = "Key";
           khoasv.ValueMember = "Value";
                try
                {
                    ketnoicsdl.Opendb("C:\\oodb.db4o");
                    IList<Sinhvien> result = (from Sinhvien p in ketnoicsdl.db

                                              select p).ToList();
                    dataGridView1.DataSource = result;
                }
                finally { ketnoicsdl.db.Close(); } 
            gioitinh.Text="NAM";
        }
        private void them_Click(object sender, EventArgs e)
        {
            masv.Text="";
            Tensv.Text="";
            ngaysinh.Text="";
            gioitinh.Text="";
            diachi.Text="";
            dienthoai.Text = "";
          MessageBox.Show( ketnoicsdl.taomatudong("sinhvien"));
        }

        private void luu_Click(object sender, EventArgs e)
        {
            Sinhvien sv = new Sinhvien();
            sv.updatesv(masv.Text, Tensv.Text, ngaysinh.Text, gioitinh.Text, diachi.Text, dienthoai.Text,
                malop.Text,khoahoc.Text,khoa.Text,nganhhoc.Text);
            
        }
        private void nhapsvexcel_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
           
            string pathToExcelFile = ""+ @openFileDialog1.FileName;
            string loi = "";
            Sinhvien sv = new Sinhvien();
           // try
           // {
                sv.nhapsv_excel(ref loi,pathToExcelFile);
                if(loi=="") 
                MessageBox.Show("Đã đọc file Excel thành công");
                else
                    MessageBox.Show("Các dòng bị lỗi " + loi); 
           // }
           // catch { MessageBox.Show("Đã có lỗi trong quá trình đọc file Excel"); }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                          
               masv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["ma"].Value);
               malop.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Malop"].Value);
               khoahoc.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Khoahoc"].Value);
               khoasv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Khoa"].Value);
               nganhhoc.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Nganhhoc"].Value);
               Tensv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Hoten"].Value);
                ngaysinh.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Ngaysinh"].Value);
                gioitinh.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Gioitinh"].Value);
                diachi.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Diachi"].Value);
                dienthoai.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Dienthoai"].Value);
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                masv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["ma"].Value);
                malop.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Malop"].Value);
                khoahoc.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Khoahoc"].Value);
                khoasv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Khoa"].Value);
                nganhhoc.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Nganhhoc"].Value);
                Tensv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Hoten"].Value);
                ngaysinh.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Ngaysinh"].Value);
                gioitinh.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Gioitinh"].Value);
                diachi.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Diachi"].Value);
                dienthoai.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Dienthoai"].Value);
            }
            catch { }
           
        }

        private void ngaysinh_Click(object sender, EventArgs e)
        {

            monthCalendar1.Show();       
           
        }
        private void ngaysinh_TextChanged(object sender, EventArgs e)
        {
            dinhdangngay.Visible = false;

        }
       

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ngaysinh.Text = monthCalendar1.SelectionStart.Day.ToString() + "/" + monthCalendar1.SelectionStart.Month.ToString() + "/" + monthCalendar1.SelectionStart.Year.ToString();
        }

        private void monthCalendar1_MouseLeave(object sender, EventArgs e)
        {
            monthCalendar1.Hide();
        }

   
        private void nhapttkhoa_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            string pathToExcelFile = ""
             + @openFileDialog1.FileName;

            string sheetName = "Sheet1";

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var docexcel = from a in excelFile.Worksheet<Khoa>(sheetName) select a;

            foreach (var a in docexcel)
            {
                Khoa kh = new Khoa();
                kh.addkhoa(a.Makhoa, a.Tenkhoa, a.Truongkhoa, a.Photruongkhoa, a.Email, a.Dienthoai, a.Dienthoai);

            }
        }

        private void xoasv_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("bạn có chắc chắn muốn xóa không?.", "Overwrite", System.Windows.Forms.MessageBoxButtons.OKCancel, 
                System.Windows.Forms.MessageBoxIcon.Asterisk, System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
            {
                Sinhvien sv = new Sinhvien();
                sv.xoasv(masv.Text);
            }

        }

       

        private void khoa_SelectedValueChanged_1(object sender, EventArgs e)
        {
            string makhoa;
            Lop lop = new Lop();
            lophoc.Items.Clear();//xoa lop moi khi chon khoa khac
            if (khoa.SelectedIndex != -1)
            {
           
           makhoa = ((KeyValuePair<string, string>)khoa.SelectedItem).Value.ToString();
            for (int i = 0; i < lop.listlop_khoa(makhoa).Count; i++)
            {
                lophoc.Items.Add(new KeyValuePair<string, string>
                    (lop.listlop_khoa(makhoa)[i].Malop, lop.listlop_khoa(makhoa)[i].Tenlop));
            }
           lophoc.DisplayMember = "Key";
           lophoc.ValueMember = "Value";
            }
        }

        private void nhapttlop_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            string pathToExcelFile = ""
             + @openFileDialog1.FileName;

            string sheetName = "Sheet1";

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var docexcel = from a in excelFile.Worksheet<Lop>(sheetName) select a;

            foreach (var a in docexcel)
            {
                Lop lop= new Lop();
                lop.addlop(a.Malop, a.Tenlop, a.Makhoa,a.Manghanh); 

            }
        }

        private void ngaysinh_Validated(object sender, EventArgs e)
        {
            if (ngaysinh.Text.CompareTo("") != 0)
            {
                if (ck.kiemtrangay(ngaysinh.Text) == 0)
                {
                    MessageBox.Show("Ngày sinh nhập không đúng ");
                    ngaysinh.Text = ""; dinhdangngay.Visible = true; 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Checkinput ck = new Checkinput();
            ck.taoexcelfilesv();
        }

        private void khoasv_SelectedValueChanged(object sender, EventArgs e)
        {
            string makhoa;
            Chuyennghanh nh = new Chuyennghanh();
            nganhhoc.Items.Clear();//xoa lop moi khi chon khoa khac
            if (khoa.SelectedIndex != -1)
            {

                makhoa = ((KeyValuePair<string, string>)khoa.SelectedItem).Value.ToString();
                for (int i = 0; i < nh.listnghanh_khoa(makhoa).Count; i++)
                {
                    lophoc.Items.Add(new KeyValuePair<string, string>
                        (nh.listnghanh_khoa(makhoa)[i].Manghanh, nh.listnghanh_khoa(makhoa)[i].Tennghanh));
                }
                lophoc.DisplayMember = "Key";
                lophoc.ValueMember = "Value";
            }
        }
    }
}
