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
    public partial class FormLopHoc : Form
    {
        private LopRepository _lh = new LopRepository();
        private KhoaRepository _khoa = new KhoaRepository();
        private Kiemtraquyen kq = new Kiemtraquyen();

        public FormLopHoc()
        {
            InitializeComponent();
        }

        private void loadDataTable()
        {
            DataTable table = _lh.getTable(txtKeyword.Text);

            table.Columns.Add("Tenkhoa").SetOrdinal(3);

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

            dgvListData.Columns["Malop"].HeaderText = "Mã lớp";
            dgvListData.Columns["Tenlop"].HeaderText = "Tên lớp";
            dgvListData.Columns["Makhoa"].HeaderText = "Mã khoa";

            dgvListData.Columns["Tenkhoa"].HeaderText = "Tên Khoa";
            dgvListData.Columns["Makhoa"].Visible = false;

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
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
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "lop", "add") == true)
            {
                if (!string.IsNullOrEmpty(txtMalop.Text))
                {
                    txtMalop.Text = "";
                    return;
                }

                Khoa kh = _khoa.getByName(cmbKhoa.Text);
                if (kh == null)
                {
                    MessageBox.Show("Có lỗi xãy ra.");
                    return;
                }

                if (_lh.isValid(txtTenlop.Text, kh.Makhoa))
                {
                    _lh.add(_lh.getNewID(), txtTenlop.Text, kh.Makhoa);
                    loadDataTable();

                    MessageBox.Show("Thêm thành công.");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "lop", "up") == true)
            {
                Khoa kh = _khoa.getByName(cmbKhoa.Text);
                if (kh == null)
                {
                    MessageBox.Show("Có lỗi xãy ra.");
                    return;
                }
                _lh.update(txtMalop.Text, txtTenlop.Text, kh.Makhoa);
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "lop", "del") == true)
            {
                _lh.delete(txtMalop.Text);
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void dgvListData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMalop.Text = dgvListData.Rows[e.RowIndex].Cells["Malop"].Value.ToString();
                txtTenlop.Text = dgvListData.Rows[e.RowIndex].Cells["Tenlop"].Value.ToString();
                cmbKhoa.Text = dgvListData.Rows[e.RowIndex].Cells["Tenkhoa"].Value.ToString();
            }
        }

        private void dgvListData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListData_RowHeaderMouseClick(sender, e);
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "lop", "add") == true)
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Title = "Nhập từ tập tin Excel";
                ofd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
                DialogResult re = ofd.ShowDialog();
                if (re == DialogResult.OK)
                {
                    if (_lh.importFromExcel(ofd.FileName))
                    {
                        loadDataTable();
                    }
                    else
                    {
                        MessageBox.Show("Nhập từ tập tin thất bại. Vui lòng kiểm tra lại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "lop", "view") == true)
            {
                SaveFileDialog ofd = new SaveFileDialog();

                ofd.Title = "Xuất tập tin Excel";
                ofd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
                DialogResult re = ofd.ShowDialog();
                if (re == DialogResult.OK)
                {
                    if (_lh.exportFromExcel(dgvListData, ofd.FileName))
                    {
                        MessageBox.Show("Xuất thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Xuất thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "lop", "view") == true)
            {
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }



    }
}
