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
namespace courcework
{
    public partial class Nhapttsv : Form
    {
        Checkinput ck = new Checkinput();
        public void an() 
        {
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
        }
        public void hien() {
         
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
        }
        public Nhapttsv()
        {
            InitializeComponent();
            monthCalendar1.Hide();
        }
        private void Nhapttsv_Load(object sender, EventArgs e)
        {
            dinhdangngay.Visible = false;
            an();
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
              /*  try
                {
                    ketnoicsdl.Opendb("C:\\oodb.db4o");
                    IList<Sinhvien> result = (from Sinhvien p in ketnoicsdl.db
                                              select p).ToList();
                    dataGridView1.DataSource = result;
                }
                finally { ketnoicsdl.db.Close(); } */
            gioitinh.Text="NAM";
            khoahoc.Text = DateTime.Now.Year.ToString();
        }
        private void them_Click(object sender, EventArgs e)
        {
            masv.Text = ketnoicsdl.taomatudong("sinhvien");
            Tensv.Text="";
            ngaysinh.Text="";
            gioitinh.Text="";
            diachi.Text="";
            dienthoai.Text = "";
          MessageBox.Show( ketnoicsdl.taomatudong("sinhvien"));
        }

        private void luu_Click(object sender, EventArgs e)
        {
            string loi = "";
            if (masv.Text == "")
                MessageBox.Show("Bạn phải bấm nút thêm trước để tạo thông tin sinh viên");
            else
            if (ck.kiemtragiatrirong(masv.Text) + ck.kiemtragiatrirong(Tensv.Text) + ck.kiemtragiatrirong(ngaysinh.Text) +
                 ck.kiemtragiatrirong(gioitinh.Text) + ck.kiemtragiatrirong(malop.Text) + ck.kiemtragiatrirong(bacdaotao.Text)
                + ck.kiemtragiatrirong(khoahoc.Text) + ck.kiemtragiatrirong(cmnd.Text) >= 1)
            {
                MessageBox.Show("Bạn phải nhập cái phần bắt buộc có dấu chấm than ");
                hien();
            }
            else
            {
                Sinhvien sv = new Sinhvien();
                sv.addsv_Luu(ref loi, masv.Text, Tensv.Text, ngaysinh.Text, gioitinh.Text, diachi.Text, Convert.ToInt32(dienthoai.Text),
                   malop.Text, bacdaotao.Text, Convert.ToInt32(khoahoc.Text), ((KeyValuePair<string, string>)khoa.SelectedItem).Value.ToString(), Convert.ToInt32(cmnd.Text));
                if (loi == "")
                    MessageBox.Show("Đã nhập thông tin thành công");
                else
                    MessageBox.Show("Các thông tin bị lỗi" + loi);
            }
            
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
                    MessageBox.Show("Các dòng bị lỗi trong file Excel bạn muốn import vào " + loi); 
           // }
           // catch { MessageBox.Show("Đã có lỗi trong quá trình đọc file Excel"); }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                          
               masv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["ma"].Value);
               malop.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Malopd"].Value);
               khoahoc.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Khoahocd"].Value);
               khoasv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Khoad"].Value);
               cmnd.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Cmndd"].Value);
               Tensv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Hoten"].Value);
                ngaysinh.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Ngaysinhd"].Value);
                gioitinh.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Gioitinhd"].Value);
                diachi.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Diachid"].Value);
                dienthoai.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Dienthoaid"].Value);
                bacdaotao.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Bacdaotaod"].Value);
            }
            catch { }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                masv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["ma"].Value);
                malop.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Malopd"].Value);
                khoahoc.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Khoahocd"].Value);
                khoasv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Khoad"].Value);
                cmnd.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Cmndd"].Value);
                Tensv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Hoten"].Value);
                ngaysinh.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Ngaysinhd"].Value);
                gioitinh.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Gioitinhd"].Value);
                diachi.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Diachid"].Value);
                dienthoai.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Dienthoaid"].Value);
                bacdaotao.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Bacdaotaod"].Value);
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
                Lop lop = new Lop();
                lop.addlop(a.Malop, a.Tenlop, a.Makhoa);

            }
            MessageBox.Show("Đã đọc file excel thành công");
            excelFile.Dispose();
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
            MessageBox.Show("Đã đọc file excel thành công");
            excelFile.Dispose();
        }

        private void xoasv_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("bạn có chắc chắn muốn xóa không?.", "Overwrite", System.Windows.Forms.MessageBoxButtons.OKCancel, 
                System.Windows.Forms.MessageBoxIcon.Asterisk, System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
            {
                Sinhvien sv = new Sinhvien();
                sv.xoasv(masv.Text);
                dataGridView1.Refresh();
            }

        }

       

        private void khoa_SelectedValueChanged_1(object sender, EventArgs e)
        {
            string makhoa;
            Lop lop = new Lop();
            List<Lop> loplist = new List<Lop>();
            
            lophoc.Items.Clear();//xoa lop moi khi chon khoa khac
            if (khoa.SelectedIndex != -1)
            {
                makhoa = ((KeyValuePair<string, string>)khoa.SelectedItem).Value.ToString();
                loplist = lop.listlop_khoa(makhoa);
           for (int i = 0; i < loplist.Count; i++)
            {
                lophoc.Items.Add(new KeyValuePair<string, string>
                    (loplist[i].Tenlop,loplist[i].Malop));
            }
           lophoc.DisplayMember = "Key";
           lophoc.ValueMember = "Value";
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
          //  string s = "";
           // s = dataGridView1.Rows[0].Cells["Ma"].Value.ToString();
            try
            {
                if (dataGridView1.Rows[0].Cells[0].Value.ToString() != "")
                    ketnoicsdl.taoexcelfilesv(dataGridView1, dataGridView1.Rows.Count );
                else MessageBox.Show("Bạn nên tìm thông tin sinh viên của khoa hoặc của lớp khi đó mới có thông tin sv để export ra được");
            }
            catch { MessageBox.Show("Bạn nên tìm thông tin sinh viên của khoa hoặc của lớp khi đó mới có thông tin sv để export ra được"); }
        }

        private void khoasv_SelectedValueChanged(object sender, EventArgs e)
        {
            string makhoa;
            Chuyennghanh nh = new Chuyennghanh();
           
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                var sv =
                    from Sinhvien p in ketnoicsdl.db
                    select p;
                //deleteOrderDetails.
                foreach (Sinhvien s in sv)
                ketnoicsdl.db.Delete(s);
                var lop =
               from Lop p in ketnoicsdl.db
               select p;
                //deleteOrderDetails.
                foreach (Lop s in lop)
                    ketnoicsdl.db.Delete(s);
                var Khoa =
               from Khoa p in ketnoicsdl.db
               select p;
                //deleteOrderDetails.
                foreach (Khoa s in Khoa)
                    ketnoicsdl.db.Delete(s);
                //ketnoicsdl.db.Commit();
            }
            finally { ketnoicsdl.db.Close(); }
        }

        private void dienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            { e.Handled = true; MessageBox.Show("Chỉ được nhập số"); }
        }



        private void cmnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            { e.Handled = true; MessageBox.Show("Chỉ được nhập số"); }
        }

        private void khoasv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn chỉ được chọn giá trị chứ không được nhập trường này");
   
        }

        private void gioitinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn chỉ được chọn giá trị chứ không được nhập trường này");
        }

        private void bacdaotao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn chỉ được chọn giá trị chứ không được nhập trường này");
        }

        private void tim_Click(object sender, EventArgs e)
        {
            Sinhvien sv= new Sinhvien();
            string makhoa = ""; 
            string malop = ""; 
            if (khoa.SelectedItem == null) makhoa = "";
            else
                makhoa = ((KeyValuePair<string, string>)khoa.SelectedItem).Value;
            if (lophoc.SelectedItem == null) malop = "";
            else malop = ((KeyValuePair<string, string>)lophoc.SelectedItem).Value;
            dataGridView1.DataSource = sv.findsv(masvt.Text.Trim(), makhoa, malop);
           dataGridView1.Refresh();
            
        }

        private void lophoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(((KeyValuePair<string, string>)lophoc.SelectedItem).Value.ToString());
        }
    }
}
