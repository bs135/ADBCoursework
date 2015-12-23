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

        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void loadDataTable()
        {
            DataTable table = _mh.getTable();
            dgvListMonHoc.Columns.Clear();
            dgvListMonHoc.DataSource = table;

            dgvListMonHoc.Columns["Mamh"].HeaderText = "Mã MH";
            dgvListMonHoc.Columns["Tenmh"].HeaderText = "Tên MH";
            dgvListMonHoc.Columns["Sochi"].HeaderText = "Số TC";
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMonHoc.Text) && string.IsNullOrEmpty(txtTenMonHoc.Text))
            {
                _mh.add(txtMaMonHoc.Text, txtTenMonHoc.Text, (int)numSoChi.Value);
                loadDataTable();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập dữ liệu.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _mh.update(txtMaMonHoc.Text, txtTenMonHoc.Text, (int)numSoChi.Value);
            loadDataTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _mh.delete(txtMaMonHoc.Text);
            loadDataTable();
        }

        private void dgvListMonHoc_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMaMonHoc.Text = dgvListMonHoc.Rows[e.RowIndex].Cells["Mamh"].Value.ToString();
            txtTenMonHoc.Text = dgvListMonHoc.Rows[e.RowIndex].Cells["Tenmh"].Value.ToString();
            numSoChi.Value = Convert.ToInt16(dgvListMonHoc.Rows[e.RowIndex].Cells["Sochi"].Value.ToString());
        }

        private void dgvListMonHoc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvListMonHoc_RowHeaderMouseClick(sender, e);
        }



    }
}
