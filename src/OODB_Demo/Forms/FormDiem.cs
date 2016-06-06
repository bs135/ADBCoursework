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
    public partial class FormDiem : Form
    {
        private DiemRepository _diem = new DiemRepository();
        private Kiemtraquyen kq = new Kiemtraquyen();

        public FormDiem()
        {
            InitializeComponent();
        }

        private void loadDataTable()
        {
            DataTable table = _diem.getTable(txtKeyword.Text);
            dgvListData.Columns.Clear();
            dgvListData.DataSource = table;

            dgvListData.Columns["Masv"].HeaderText = "Mã SV";
            dgvListData.Columns["Mamh"].HeaderText = "Mã MH";
            dgvListData.Columns["Diem"].HeaderText = "Điểm";
            dgvListData.Columns["Lanthu"].HeaderText = "Lần thứ";
            dgvListData.Columns["Ghichu"].HeaderText = "Ghi chú";
            dgvListData.Columns["Hocki"].HeaderText = "Học kì";

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "diemsinhvien", "add") == true)
            {
                double diem;
                int lanthu;
                if (!double.TryParse(txtDiem.Text, out diem) || (diem < 0) || (diem > 10))
                {
                    MessageBox.Show("Nhập \"Điểm\" không hợp lệ");
                    return;
                }
                if (!int.TryParse(textLanthu.Text, out lanthu))
                {
                    MessageBox.Show("Nhập \"Lần thứ\" không hợp lệ");
                    return;
                }
                if (_diem.isValid(txtMaSV.Text, txtMaMonHoc.Text, diem, lanthu, textGhichu.Text, textHocki.Text))
                {
                    if (_diem.isExist(txtMaMonHoc.Text, txtMaSV.Text))
                    {
                        MessageBox.Show("Mã môn học đã tồn tại.");
                        return;
                    }
                    _diem.add(txtMaSV.Text, txtMaMonHoc.Text, diem, lanthu, textGhichu.Text, textHocki.Text);
                    loadDataTable();
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
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "diemsinhvien", "up") == true)
            {
                double diem;
                int lanthu;
                if (!double.TryParse(txtDiem.Text, out diem) || (diem < 0) || (diem > 10))
                {
                    MessageBox.Show("Nhập \"Điểm\" không hợp lệ");
                    return;
                }
                if (!int.TryParse(textLanthu.Text, out lanthu))
                {
                    MessageBox.Show("Nhập \"Lần thứ\" không hợp lệ");
                    return;
                }
                _diem.update(txtMaSV.Text, txtMaMonHoc.Text, diem, lanthu, textGhichu.Text, textHocki.Text);
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện lệnh này");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "diemsinhvien", "del") == true)
            {
                _diem.delete(txtMaMonHoc.Text, txtMaSV.Text);
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
                txtMaSV.Text = dgvListData.Rows[e.RowIndex].Cells["Masv"].Value.ToString();
                txtMaMonHoc.Text = dgvListData.Rows[e.RowIndex].Cells["Mamh"].Value.ToString();
                txtDiem.Text = dgvListData.Rows[e.RowIndex].Cells["Diem"].Value.ToString();
                textLanthu.Text = dgvListData.Rows[e.RowIndex].Cells["Lanthu"].Value.ToString();
                textGhichu.Text = dgvListData.Rows[e.RowIndex].Cells["Ghichu"].Value.ToString();
                textHocki.Text = dgvListData.Rows[e.RowIndex].Cells["Hocki"].Value.ToString();
            }
        }

        private void dgvListData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListData_RowHeaderMouseClick(sender, e);
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "diemsinhvien", "add") == true)
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Title = "Nhập từ tập tin Excel";
                ofd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
                DialogResult re = ofd.ShowDialog();
                if (re == DialogResult.OK)
                {
                    if (_diem.importFromExcel(ofd.FileName))
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
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "diemsinhvien", "view") == true)
            {
                SaveFileDialog ofd = new SaveFileDialog();

                ofd.Title = "Xuất tập tin Excel";
                ofd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
                DialogResult re = ofd.ShowDialog();
                if (re == DialogResult.OK)
                {
                    if (_diem.exportFromExcel(dgvListData, ofd.FileName))
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
            if (kq.kiemtraquyenuser(FormDangnhap.loginUsename, "diemsinhvien", "view") == true)
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
