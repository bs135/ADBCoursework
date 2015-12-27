using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OODBDemo.Repositories;
using OODBDemo.Entities;
using OODBDemo.Utilities;

namespace OODBDemo
{
    public partial class FormGiaoVien : Form
    {
        private GiaoVienRepository _gv = new GiaoVienRepository();

        public FormGiaoVien()
        {
            InitializeComponent();
        }

        private void loadDataTable()
        {
            DataTable table = _gv.getTable();
            dgvListData.Columns.Clear();
            dgvListData.DataSource = table;

            dgvListData.Columns["Ma"].HeaderText = "Mã";
            dgvListData.Columns["Hoten"].HeaderText = "Họ tên";
            dgvListData.Columns["Ngaysinh"].HeaderText = "Ngày sinh";
            dgvListData.Columns["Gioitinh"].HeaderText = "Giới tính";
            dgvListData.Columns["Diachi"].HeaderText = "Địa chỉ";
            dgvListData.Columns["Dienthoai"].HeaderText = "Điện thoại";
            dgvListData.Columns["Email"].HeaderText = "Email";
            dgvListData.Columns["Makhoa"].HeaderText = "Mã khoa";
            dgvListData.Columns["Trinhdo"].HeaderText = "Trình độ";
            dgvListData.Columns["Phanloai"].HeaderText = "Phân loại";
            dgvListData.Columns["Quoctich"].HeaderText = "Quốc tịch";
            dgvListData.Columns["Nangkhieu"].HeaderText = "Năng khiếu";

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_gv.isValid(txtMa.Text, txtHoTen.Text, dtimeNgaySinh.Value.ToString("dd/MM/yyyy"), txtGioiTinh.Text, txtDiaChi.Text, txtDienThoai.Text.toInt(), txtEmail.Text, txtMaKhoa.Text, txtTrinhDo.Text, txtPhanLoai.Text, txtQuocTich.Text, txtNangKhieu.Text))
            {
                if (_gv.isExist(txtMa.Text))
                {
                    MessageBox.Show("Mã môn học đã tồn tại.");
                    return;
                }
                _gv.add(txtMa.Text, txtHoTen.Text, dtimeNgaySinh.Value.ToString("dd/MM/yyyy"), txtGioiTinh.Text, txtDiaChi.Text, txtDienThoai.Text.toInt(), txtEmail.Text, txtMaKhoa.Text, txtTrinhDo.Text, txtPhanLoai.Text, txtQuocTich.Text, txtNangKhieu.Text);
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _gv.update(txtMa.Text, txtHoTen.Text, dtimeNgaySinh.Value.ToString("dd/MM/yyyy"), txtGioiTinh.Text, txtDiaChi.Text, txtDienThoai.Text.toInt(), txtEmail.Text, txtMaKhoa.Text, txtTrinhDo.Text, txtPhanLoai.Text, txtQuocTich.Text, txtNangKhieu.Text);
            loadDataTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _gv.delete(txtMa.Text);
            loadDataTable();
        }

        private void dgvListData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMa.Text = dgvListData.Rows[e.RowIndex].Cells["Ma"].Value.ToString();
            txtHoTen.Text = dgvListData.Rows[e.RowIndex].Cells["Hoten"].Value.ToString();
            dtimeNgaySinh.Value = dgvListData.Rows[e.RowIndex].Cells["Ngaysinh"].Value.ToString().toDate();
            txtGioiTinh.Text = dgvListData.Rows[e.RowIndex].Cells["Gioitinh"].Value.ToString();
            txtDiaChi.Text = dgvListData.Rows[e.RowIndex].Cells["Diachi"].Value.ToString();
            txtDienThoai.Text = dgvListData.Rows[e.RowIndex].Cells["Dienthoai"].Value.ToString();
            txtEmail.Text = dgvListData.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            txtMaKhoa.Text = dgvListData.Rows[e.RowIndex].Cells["Makhoa"].Value.ToString();
            txtTrinhDo.Text = dgvListData.Rows[e.RowIndex].Cells["Trinhdo"].Value.ToString();
            txtPhanLoai.Text = dgvListData.Rows[e.RowIndex].Cells["Phanloai"].Value.ToString();
            txtQuocTich.Text = dgvListData.Rows[e.RowIndex].Cells["Quoctich"].Value.ToString();
            txtNangKhieu.Text = dgvListData.Rows[e.RowIndex].Cells["Nangkhieu"].Value.ToString();
        }

        private void dgvListData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListData_RowHeaderMouseClick(sender, e);
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Nhập từ tập tin Excel";
            ofd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
            DialogResult re = ofd.ShowDialog();
            if (re == DialogResult.OK)
            {
                if (_gv.importFromExcel(ofd.FileName))
                {
                    loadDataTable();
                }
                else
                {
                    MessageBox.Show("Nhập từ tập tin thất bại. Vui lòng kiểm tra lại.");
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();

            ofd.Title = "Xuất tập tin Excel";
            ofd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
            DialogResult re = ofd.ShowDialog();
            if (re == DialogResult.OK)
            {
                if (_gv.exportFromExcel(dgvListData, ofd.FileName))
                {
                    MessageBox.Show("Xuất thành công.");
                }
                else
                {
                    MessageBox.Show("Xuất thất bại.");
                }
            }
        }



    }
}
