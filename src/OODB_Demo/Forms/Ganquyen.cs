using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace courcework
{
    public partial class Ganquyen : Form
    {
        public Ganquyen()
        {
            InitializeComponent();
        }

        private void Ganquyen_Load(object sender, EventArgs e)
        {
            
            List<string> listname = new List<string>() {"Sinh viên","Điểm sinh viên","Giáo viên","Hạnh Kiểm","Khoa","Lớp","Môn học" };
            List<string> listvalue = new List<string>() { "sinhvien", "diemsv", "giaovien", "hanhkiem", "khoa", "lop", "monhoc" };
            for (int i = 0; i < 7;i++ )
            {
            gthem.Items.Add(new KeyValuePair<string, string>(listname[i], listvalue[i]));
            gxoa.Items.Add(new KeyValuePair<string, string>(listname[i], listvalue[i]));
            gsua.Items.Add(new KeyValuePair<string, string>(listname[i], listvalue[i]));
            gxem.Items.Add(new KeyValuePair<string, string>(listname[i], listvalue[i]));
            doituong.Items.Add(new KeyValuePair<string, string>(listname[i], listvalue[i]));
            }
            gthem.ValueMember = "Value";
            gthem.DisplayMember = "Key";
            gxoa.ValueMember = "Value";
            gxoa.DisplayMember = "Key";
            gsua.ValueMember = "Value";
            gsua.DisplayMember = "Key";
            gxem.ValueMember = "Value";
            gxem.DisplayMember = "Key";
            doituong.ValueMember = "Value";
            doituong.DisplayMember = "Key";
        }

        private void gthem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn chỉ được chọn giá trị chứ không được nhập trường này");
        }

        private void gsua_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn chỉ được chọn giá trị chứ không được nhập trường này");
        }

        private void gxoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn chỉ được chọn giá trị chứ không được nhập trường này");
        }

        private void gxem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn chỉ được chọn giá trị chứ không được nhập trường này");
        }

        private void doituong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Bạn chỉ được chọn giá trị chứ không được nhập trường này");
        }

        private void doituong_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
