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
    public partial class FormMonHoc : Form
    {
        private MonHocRepository _mh = new MonHocRepository();
        private Kiemtraquyen kq = new Kiemtraquyen();

        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void loadDataTable()
        {
            DataTable table = _mh.getTable(txtKeyword.Text);
            dgvListData.Columns.Clear();
            dgvListData.DataSource = table;

            dgvListData.Columns["Mamh"].HeaderText = "Mã MH";
            dgvListData.Columns["Tenmh"].HeaderText = "Tên MH";
            dgvListData.Columns["Sochi"].HeaderText = "Số TC";
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "monhoc", "add") == true)
            {
                if (!string.IsNullOrEmpty(txtMaMonHoc.Text))
                {
                    txtMaMonHoc.Text = "";
                    return;
                }

                if (_mh.isValid(txtTenMonHoc.Text, (int)numSoChi.Value))
                {
                    _mh.add(_mh.getNewID(), txtTenMonHoc.Text, (int)numSoChi.Value);
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
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "monhoc", "up") == true)
            {
                _mh.update(txtMaMonHoc.Text, txtTenMonHoc.Text, (int)numSoChi.Value);
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "monhoc", "del") == true)
            {
                _mh.delete(txtMaMonHoc.Text);
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
                txtMaMonHoc.Text = dgvListData.Rows[e.RowIndex].Cells["Mamh"].Value.ToString();
                txtTenMonHoc.Text = dgvListData.Rows[e.RowIndex].Cells["Tenmh"].Value.ToString();
                numSoChi.Value = Convert.ToInt16(dgvListData.Rows[e.RowIndex].Cells["Sochi"].Value.ToString());
            }
        }

        private void dgvListData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListData_RowHeaderMouseClick(sender, e);
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "monhoc", "add") == true)
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Title = "Nhập từ tập tin Excel";
                ofd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
                DialogResult re = ofd.ShowDialog();
                if (re == DialogResult.OK)
                {
                    if (_mh.importFromExcel(ofd.FileName))
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
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "monhoc", "view") == true)
            {
                SaveFileDialog ofd = new SaveFileDialog();

                ofd.Title = "Xuất tập tin Excel";
                ofd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
                DialogResult re = ofd.ShowDialog();
                if (re == DialogResult.OK)
                {
                    if (_mh.exportFromExcel(dgvListData, ofd.FileName))
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
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "monhoc", "view") == true)
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
