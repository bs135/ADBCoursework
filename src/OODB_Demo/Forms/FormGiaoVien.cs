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
        private KhoaRepository _khoa = new KhoaRepository();

        public FormGiaoVien()
        {
            InitializeComponent();
        }

        private void loadDataTable()
        {
            DataTable table = _gv.getTable(txtKeyword.Text);

            table.Columns.Add("Tenkhoa").SetOrdinal(8);

            Khoa kh;
            foreach (DataRow row in table.Rows)
            {
                kh = _khoa.getById(row["Makhoa"].ToString());
                if (kh != null)
                {
                    row["Tenkhoa"] = kh.Tenkhoa;
                }
            }

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
            dgvListData.Columns["Cmnd"].HeaderText = "CMND";
            dgvListData.Columns["Quoctich"].HeaderText = "Quốc tịch";
            dgvListData.Columns["Nangkhieu"].HeaderText = "Năng khiếu";

            dgvListData.Columns["Tenkhoa"].HeaderText = "Tên Khoa";
            dgvListData.Columns["Makhoa"].Visible = false;
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            cmbGioiTinh.Items.Clear();
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.SelectedIndex = 0;

            cmbTrinhDo.Items.Clear();
            cmbTrinhDo.Items.Add("Cao đẳng");
            cmbTrinhDo.Items.Add("Đại học");
            cmbTrinhDo.Items.Add("Trên đại học");
            cmbTrinhDo.SelectedIndex = 0;

            IEnumerable<Khoa> listkhoa = _khoa.getAll();
            cmbKhoa.Items.Clear();
            foreach (Khoa kh in listkhoa)
            {
                cmbKhoa.Items.Add(kh.Tenkhoa);
            }
            if (cmbKhoa.Items.Count > 0) cmbKhoa.SelectedIndex = 0;

            loadDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMa.Text))
            {
                txtMa.Text = "";
                return;
            }

            Khoa kh = _khoa.getByName(cmbKhoa.Text);
            if (kh == null)
            {
                MessageBox.Show("Có lỗi xãy ra.");
                return;
            }

            if (_gv.isValid(txtHoTen.Text, dtimeNgaySinh.Value.ToString("dd/MM/yyyy"), cmbGioiTinh.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, kh.Makhoa, cmbTrinhDo.Text, txtCMND.Text, txtQuocTich.Text, txtNangKhieu.Text))
            {
                if (_gv.isExist(txtMa.Text))
                {
                    MessageBox.Show("Mã môn học đã tồn tại.");
                    return;
                }
                _gv.add(_gv.getNewID(), txtHoTen.Text, dtimeNgaySinh.Value.ToString("dd/MM/yyyy"), cmbGioiTinh.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, kh.Makhoa, cmbTrinhDo.Text, txtCMND.Text, txtQuocTich.Text, txtNangKhieu.Text);
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Khoa kh = _khoa.getByName(cmbKhoa.Text);
            if (kh == null)
            {
                MessageBox.Show("Có lỗi xãy ra.");
                return;
            }

            _gv.update(txtMa.Text, txtHoTen.Text, dtimeNgaySinh.Value.ToString("dd/MM/yyyy"), cmbGioiTinh.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, kh.Makhoa, cmbTrinhDo.Text, txtCMND.Text, txtQuocTich.Text, txtNangKhieu.Text);
            loadDataTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _gv.delete(txtMa.Text);
            loadDataTable();
        }

        private void dgvListData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMa.Text = dgvListData.Rows[e.RowIndex].Cells["Ma"].Value.ToString();
                txtHoTen.Text = dgvListData.Rows[e.RowIndex].Cells["Hoten"].Value.ToString();
                dtimeNgaySinh.Value = dgvListData.Rows[e.RowIndex].Cells["Ngaysinh"].Value.ToString().toDate();
                cmbGioiTinh.Text = dgvListData.Rows[e.RowIndex].Cells["Gioitinh"].Value.ToString();
                txtDiaChi.Text = dgvListData.Rows[e.RowIndex].Cells["Diachi"].Value.ToString();
                txtDienThoai.Text = dgvListData.Rows[e.RowIndex].Cells["Dienthoai"].Value.ToString();
                txtEmail.Text = dgvListData.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                cmbKhoa.Text = dgvListData.Rows[e.RowIndex].Cells["Tenkhoa"].Value.ToString();
                cmbTrinhDo.Text = dgvListData.Rows[e.RowIndex].Cells["Trinhdo"].Value.ToString();
                txtCMND.Text = dgvListData.Rows[e.RowIndex].Cells["Cmnd"].Value.ToString();
                txtQuocTich.Text = dgvListData.Rows[e.RowIndex].Cells["Quoctich"].Value.ToString();
                txtNangKhieu.Text = dgvListData.Rows[e.RowIndex].Cells["Nangkhieu"].Value.ToString();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadDataTable();
        }



    }
}
