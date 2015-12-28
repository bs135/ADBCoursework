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

namespace OODBDemo
{
    public partial class FormKhoa : Form
    {
        private KhoaRepository _khoa = new KhoaRepository();

        public FormKhoa()
        {
            InitializeComponent();
        }

        private void loadDataTable()
        {
            DataTable table = _khoa.getTable(txtKeyword.Text);
            dgvListData.Columns.Clear();
            dgvListData.DataSource = table;

            dgvListData.Columns["Makhoa"].HeaderText = "Mã Khoa";
            dgvListData.Columns["Tenkhoa"].HeaderText = "Tên Khoa";
            dgvListData.Columns["Truongkhoa"].HeaderText = "Trưởng Khoa";
            dgvListData.Columns["Photruongkhoa"].HeaderText = "P. Trưởng Khoa";
            dgvListData.Columns["Email"].HeaderText = "Email";
            dgvListData.Columns["Diachi"].HeaderText = "Địa chỉ";
            dgvListData.Columns["Dienthoai"].HeaderText = "Điện thoại";
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_khoa.isValid(txtMaKhoa.Text, txtTenKhoa.Text, txtTruongKhoa.Text, txtPhoTruongKhoa.Text, txtEmail.Text, txtDiaChi.Text, txtDienThoai.Text))
            {
                if (_khoa.isExist(txtMaKhoa.Text))
                {
                    MessageBox.Show("Mã khoa đã tồn tại.");
                    return;
                }
                _khoa.add(txtMaKhoa.Text, txtTenKhoa.Text, txtTruongKhoa.Text, txtPhoTruongKhoa.Text, txtEmail.Text, txtDiaChi.Text, txtDienThoai.Text);
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _khoa.update(txtMaKhoa.Text, txtTenKhoa.Text, txtTruongKhoa.Text, txtPhoTruongKhoa.Text, txtEmail.Text, txtDiaChi.Text, txtDienThoai.Text);
            loadDataTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _khoa.delete(txtMaKhoa.Text);
            loadDataTable();
        }

        private void dgvListData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKhoa.Text = dgvListData.Rows[e.RowIndex].Cells["Makhoa"].Value.ToString();
                txtTenKhoa.Text = dgvListData.Rows[e.RowIndex].Cells["Tenkhoa"].Value.ToString();
                txtTruongKhoa.Text = dgvListData.Rows[e.RowIndex].Cells["Truongkhoa"].Value.ToString();
                txtPhoTruongKhoa.Text = dgvListData.Rows[e.RowIndex].Cells["Photruongkhoa"].Value.ToString();
                txtEmail.Text = dgvListData.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtDiaChi.Text = dgvListData.Rows[e.RowIndex].Cells["Diachi"].Value.ToString();
                txtDienThoai.Text = dgvListData.Rows[e.RowIndex].Cells["Dienthoai"].Value.ToString();
            }
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
                if (_khoa.importFromExcel(ofd.FileName))
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
                if (_khoa.exportFromExcel(dgvListData, ofd.FileName))
                {
                    MessageBox.Show("Xuất thành công.");
                }
                else
                {
                    MessageBox.Show("Xuất thất bại.");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadDataTable();
        }



    }
}
