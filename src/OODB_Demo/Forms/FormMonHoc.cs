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

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            DataTable table = _mh.getTable();
            dgvListMonHoc.Columns.Clear();
            dgvListMonHoc.DataSource = table;
        }

    }
}
