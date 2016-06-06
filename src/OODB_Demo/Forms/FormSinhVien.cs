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
using OODBDemo.Entities;
using OODBDemo.Repositories;
using OODBDemo.DBAccess;
namespace OODBDemo
{
    public partial class FormSinhVien : Form
    {
        DBConnect dbConnect = new DBConnect();
        Checkinput ck = new Checkinput();
        Kiemtraquyen kq = new Kiemtraquyen();
        KhoaRepository kh = new KhoaRepository();
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
        public void hien()
        {

            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
        }
        public FormSinhVien()
        {
            InitializeComponent();
            monthCalendar1.Hide();
        }
        private void Nhapttsv_Load(object sender, EventArgs e)
        {

            dinhdangngay.Visible = false;
            an();
            ngaysinh.Text = "01/01/1997";
            KhoaRepository kh = new KhoaRepository();

            for (int i = 0; i < kh.listkhoa().Count; i++)
            {
                khoa.Items.Add(new KeyValuePair<string, string>(kh.listkhoa()[i].Tenkhoa, kh.listkhoa()[i].Makhoa));
                khoasv.Items.Add(new KeyValuePair<string, string>(kh.listkhoa()[i].Tenkhoa, kh.listkhoa()[i].Makhoa));


            }
            khoa.DisplayMember = "Key";
            khoa.ValueMember = "Value";
            khoasv.DisplayMember = "Key";
            khoasv.ValueMember = "Value";

            /*  try
              {
                  dbConnect.Open();
                  IList<Sinhvien> result = (from Sinhvien p in dbConnect.db
                                            select p).ToList();
                  dataGridView1.DataSource = result;
              }
              finally { dbConnect.db.Close(); } */
            gioitinh.Text = "NAM";
            khoahoc.Text = DateTime.Now.Year.ToString();
        }
        private void them_Click(object sender, EventArgs e)
        {
            string ma = ketnoicsdl.taomatudong("sinhvien");
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "sinhvien", "add") == true)
            {
                if (masv.Text.Trim() != "")
                {
                    masv.Text = "";
                }
                else
                {
                    string loi = "";

                    if (ck.kiemtragiatrirong(Tensv.Text) + ck.kiemtragiatrirong(ngaysinh.Text) +
                         ck.kiemtragiatrirong(gioitinh.Text) + ck.kiemtragiatrirong(cmbLop.Text) + ck.kiemtragiatrirong(bacdaotao.Text)
                        + ck.kiemtragiatrirong(khoahoc.Text) + ck.kiemtragiatrirong(cmnd.Text) >= 1)
                    {
                        MessageBox.Show("Bạn phải nhập cái phần bắt buộc có dấu chấm than ");
                        hien();
                    }
                    else
                    {
                        SinhVienRepositories sv = new SinhVienRepositories();
                        try
                        {
                            sv.addsv_Luu(ref loi, ma, Tensv.Text, ngaysinh.Text, gioitinh.Text, diachi.Text, dienthoai.Text,
                               cmbLop.Text, bacdaotao.Text, Convert.ToInt32(khoahoc.Text), ((KeyValuePair<string, string>)khoasv.SelectedItem).Value.ToString(), Convert.ToInt32(cmnd.Text));
                        }
                        catch { MessageBox.Show("Đã có thuộc tính null trong thông tin sinh viên"); }
                        if (loi == "")
                            MessageBox.Show("Đã nhập thông tin thành công");
                        else
                            MessageBox.Show("Các thông tin bị lỗi" + loi);
                    }
                    //   MessageBox.Show(ketnoicsdl.taomatudong("sinhvien"));
                }
                /*  else { 
                      masv.Text = ketnoicsdl.taomatudong("sinhvien");
                      Tensv.Text = "";
                      diachi.Text = "";
                      dienthoai.Text = "";
                      cmnd.Text = "";

                  }*/
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void luu_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "sinhvien", "up") == true)
            {
                Khoa k = kh.getByName(khoasv.Text);
                SinhVienRepositories sv = new SinhVienRepositories();
                if (sv.updatesv(masv.Text, Tensv.Text, ngaysinh.Text, diachi.Text, gioitinh.Text, dienthoai.Text,
                                 cmbLop.Text, khoahoc.Text, k.Makhoa, bacdaotao.Text, cmnd.Text) == 1)
                    MessageBox.Show("Bạn đã cập nhật thành công");
            }

            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }
        private void nhapsvexcel_Click(object sender, EventArgs e)
        {

            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "sinhvien", "add") == true)
            {
                openFileDialog1.ShowDialog();

                string pathToExcelFile = "" + @openFileDialog1.FileName;
                string loi = "";
                SinhVienRepositories sv = new SinhVienRepositories();
                // try
                // {
                sv.nhapsv_excel(ref loi, pathToExcelFile);
                if (loi == "")
                    MessageBox.Show("Đã đọc file Excel thành công");
                else
                    MessageBox.Show("Các dòng bị lỗi trong file Excel bạn muốn import vào " + loi);
                // }
                // catch { MessageBox.Show("Đã có lỗi trong quá trình đọc file Excel"); }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                masv.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["ma"].Value);
                cmbLop.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Malopd"].Value);
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
                cmbLop.Text = ck.kiemtranull(dataGridView1.Rows[e.RowIndex].Cells["Malopd"].Value);
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


        private void xoasv_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "sinhvien", "del") == true)
            {
                if (System.Windows.Forms.MessageBox.Show("bạn có chắc chắn muốn xóa không?.", "Overwrite", System.Windows.Forms.MessageBoxButtons.OKCancel,
                   System.Windows.Forms.MessageBoxIcon.Asterisk, System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    SinhVienRepositories sv = new SinhVienRepositories();
                    if (sv.xoasv(masv.Text) == 1)
                        MessageBox.Show("Bạn đã xóa thành công");
                    dataGridView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
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
                        (loplist[i].Tenlop, loplist[i].Malop));
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
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn vị trí lưu";
            sf.Filter = "Excel file (*.xls, *.xlsx)|*.xlsx;*.xls";
            DialogResult re = sf.ShowDialog();
            if (re == DialogResult.OK)
            {
                if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "sinhvien", "view") == true)
                {
                    try
                    {
                        if (dataGridView1.Rows[0].Cells[0].Value.ToString() != "")
                        {
                            ketnoicsdl.taoexcelfilesv(dataGridView1, dataGridView1.Rows.Count, sf.FileName);
                            MessageBox.Show("Đã xuất file Excel thành công");
                        }
                        else
                        {
                            MessageBox.Show("Bạn nên tìm thông tin sinh viên của khoa hoặc của lớp khi đó mới có thông tin sv để export ra được");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Bạn nên tìm thông tin sinh viên của khoa hoặc của lớp khi đó mới có thông tin sv để export ra được");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnect.Open();
                var sv =
                    from Sinhvien p in dbConnect.db
                    select p;
                //deleteOrderDetails.
                foreach (Sinhvien s in sv)
                    dbConnect.db.Delete(s);
                var lop =
               from Lop p in dbConnect.db
               select p;
                //deleteOrderDetails.
                foreach (Lop s in lop)
                    dbConnect.db.Delete(s);
                var Khoa =
               from Khoa p in dbConnect.db
               select p;
                //deleteOrderDetails.
                foreach (Khoa s in Khoa)
                    dbConnect.db.Delete(s);
                //dbConnect.db.Commit();
            }
            finally { dbConnect.db.Close(); }
        }

        private void dienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            { e.Handled = true; MessageBox.Show("Chỉ được nhập số"); }
        }



        private void cmnd_KeyPress(object sender, KeyPressEventArgs e)
        {

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
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "sinhvien", "view") == true)
            {
                SinhVienRepositories sv = new SinhVienRepositories();
                string makhoa = "";
                string malop = "";
                if (khoa.SelectedItem == null) makhoa = "";
                else
                    makhoa = ((KeyValuePair<string, string>)khoa.SelectedItem).Value;
                if (lophoc.SelectedItem == null) malop = "";
                else malop = ((KeyValuePair<string, string>)lophoc.SelectedItem).Value;
                dataGridView1.DataSource = sv.findsv(masvt.Text.Trim(), makhoa, malop);
                /*  if (dataGridView1.RowCount > 0)
                      for (int i = 0; i < dataGridView1.RowCount; i++)
                          dataGridView1.Rows[i].Cells["Ma"].Value = "Bạn ko có quyền xem";*/
                dataGridView1.Refresh();

            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void lophoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(((KeyValuePair<string, string>)lophoc.SelectedItem).Value.ToString());
        }

        private void khoasv_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(((KeyValuePair<string, string>)khoa.SelectedItem).Value.ToString());
            if (khoasv.SelectedItem != null)
            {
                Lop lop = new Lop();
                //   MessageBox.Show( ((KeyValuePair<string, string>)khoasv).Value.ToString());
                try
                {

                    for (int i = 0; i < lop.listlop_khoa(((KeyValuePair<string, string>)khoasv.SelectedItem).Value).Count; i++)
                    {
                        //  khoa.Items.Add(new KeyValuePair<string, string>(kh.listkhoa()[i].Tenkhoa, kh.listkhoa()[i].Makhoa));
                        cmbLop.Items.Add(new KeyValuePair<string, string>(lop.listlop_khoa(((KeyValuePair<string, string>)khoasv.SelectedItem).Value.ToString())[i].Malop, lop.listlop_khoa(((KeyValuePair<string, string>)khoasv.SelectedItem).Value.ToString())[i].Malop));
                    }
                    cmbLop.DisplayMember = "Key";
                    cmbLop.ValueMember = "Value";
                }
                catch { };
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            try
            {

                dbConnect.Open();

                List<Sinhvien> svdel = (from Sinhvien p in dbConnect.db
                                        select p).ToList();
                if (svdel != null)
                {
                    foreach (Sinhvien s in svdel)
                        dbConnect.db.Delete(s);
                }
                MessageBox.Show("da xoa het");
            }
            catch { MessageBox.Show("xoa bi loi"); }
            finally
            {
                dbConnect.Close();
            }
        }

    }
}
