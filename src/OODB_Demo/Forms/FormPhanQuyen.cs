using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.CS.Config;
using Db4objects.Db4o.Linq;
using LinqToExcel;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
using OODBDemo.DBAccess;
using OODBDemo.Utilities;
namespace OODBDemo
{
    public partial class FormPhanQuyen : Form
    {
        //public Capquyen capq = new Capquyen();
        Group g = new Group();
        User u = new User();
        Quyen_group qg = new Quyen_group();
        Quyen_user qu = new Quyen_user();

        DBConnect dbConnect = new DBConnect();

        List<string> listvalue = new List<string>() {"phanquyen", "sinhvien", "diemsinhvien", "giaovien", "khoa", "lop", "monhoc" };

        public FormPhanQuyen()
        {
            InitializeComponent();
        }

        private void Ganquyen_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < u.listuser().Count; i++)
                {
                    listuser.Items.Add(u.listuser()[i].Username);
                    listug.Items.Add(u.listuser()[i].Username);
                }
           }
            catch { }
            for (int i = 0; i < 7; i++)
            {
                gthem.Items.Add(new KeyValuePair<string, string>(listvalue[i], listvalue[i]));
            }
            for (int i = 0; i < g.listgroup().Count; i++)
            {
                string gname = g.listgroup()[i].namegroup;
                cgroup.Items.Add(gname);
                tgroup.Items.Add(gname);
                timgroup.Items.Add(gname);
            }
            //for (int i = 0; i < qg.listgroup().Count; i++)
            //{
            //    tgroup.Items.Add(new KeyValuePair<string, string>(qg.listgroup()[i], qg.listgroup()[i]));
            //    timgroup.Items.Add(qg.listgroup()[i]);
            //}
           
            gthem.DisplayMember = "Key";
            gthem.ValueMember = "Value";
            //tgroup.DisplayMember = "Key";
            //tgroup.ValueMember = "Value";
            
            
        }
        public void refesh()
        {
            listug.Items.Clear();
            listuser.Items.Clear();
            timgroup.Items.Clear();
            listug.Items.Clear();
            tgroup.Items.Clear();
            cgroup.Items.Clear();
            gthem.Items.Clear();
            try
            {
                for (int i = 0; i < u.listuser().Count; i++)
                {
                    string uname = u.listuser()[i].Username;
                    listuser.Items.Add(uname);
                    listug.Items.Add(uname);
                }
            }
            catch { }
            for (int i = 0; i < 6; i++)
            {
                gthem.Items.Add(listvalue[i]);
            }
            for (int i = 0; i < g.listgroup().Count; i++)
            {
                string gname = g.listgroup()[i].namegroup;
                cgroup.Items.Add(gname);
                tgroup.Items.Add(gname);
                timgroup.Items.Add(gname);
            }
            //for (int i = 0; i < qg.listgroup().Count; i++)
            //{
            //    tgroup.Items.Add(qg.listgroup()[i]);
            //    timgroup.Items.Add(qg.listgroup()[i]);
            //}

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

        private void cthem_CheckedChanged(object sender, EventArgs e)
        {
            //   MessageBox.Show(cthem.Checked.ToString());
            if (cthem.Checked == true)
            {
                csua.Checked = true; csua.AutoCheck = false;
                cxem.Checked = true; cxem.AutoCheck = false;
            }
            else if (cxoa.Checked != true)
            {
                csua.Checked = false; csua.AutoCheck = true;
                cxem.Checked = false; cxem.AutoCheck = true;
            }
        }
        private void cxoa_CheckedChanged(object sender, EventArgs e)
        {
            if (cxoa.Checked == true)
            {
                csua.Checked = true; csua.AutoCheck = false;
                cxem.Checked = true; cxem.AutoCheck = false;
            }
            else if (cthem.Checked != true)
            {
                csua.Checked = false; csua.AutoCheck = true;
                cxem.Checked = false; cxem.AutoCheck = true;
            }
        }

        private void csua_CheckedChanged(object sender, EventArgs e)
        {
            if (csua.Checked == true)
            {

                cxem.Checked = true; cxem.AutoCheck = false;
            }
            else
            {

                cxem.Checked = false; cxem.AutoCheck = true;
            }
        }

        private void Taogroup_Click(object sender, EventArgs e)
        {
            Group g = new Group();
            if (tengroup.Text.Trim() != "")
            {
                g.addgroup(tengroup.Text);
            }
            else
                MessageBox.Show("bạn chưa nhập tên group");
            refesh();
        }

        private void cgroup_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
            Quyen_group qg = new Quyen_group();

            if (gthem.Text.Trim() != "")
            {
                qg = qg.timquyen_group(cgroup.Text, gthem.Text);
                if (qg != null)
                {
                    cthem.Checked = qg.Add;
                    cxoa.Checked = qg.Del;
                    csua.Checked = qg.Up;
                    cxem.Checked = qg.View;
                }
            }
        }

        private void gthem_SelectedValueChanged(object sender, EventArgs e)
        {
            Quyen_group qg = new Quyen_group();

            if (cgroup.Text.Trim() != "")
            {
                qg = qg.timquyen_group(cgroup.Text, gthem.Text);
                if (qg != null)
                {
                    cthem.Checked = qg.Add;
                    cxoa.Checked = qg.Del;
                    csua.Checked = qg.Up;
                    cxem.Checked = qg.View;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            User g = new User();
            Decode mahoa = new Decode();
            if (tenuser.Text.Trim() != "" && pass.Text.Trim() != "")
                g.adduser(tenuser.Text, mahoa.Encrypt(pass.Text.Trim(),"ahung_dhung_hai_huu",null));
            else
                MessageBox.Show("bạn chưa nhập tên user hoặc password");
            refesh();
        }


        private void tim_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("User");
                dt.Columns.Add("Group");
                dt.Columns.Add("Password");
                dt.Columns.Add("Doituong");
                dt.Columns.Add("Add");
                dt.Columns.Add("Del");
                dt.Columns.Add("Up");
                dt.Columns.Add("View");

                dbConnect.Open();
                var sva = (from User p in dbConnect.db
                           join Quyen_user k in dbConnect.db
                           on p.Username equals k.User
                           where p.Username == listuser.Text
                           select new { p.Username, p.Password, k.Group, k.Doituong, k.Add, k.Del, k.Up, k.View });
                foreach (var p in sva)
                {
                    var row = dt.NewRow();

                    row["User"] = p.Username;
                    row["Group"] = p.Group;
                    row["Password"] = p.Password;
                    row["Doituong"] = p.Doituong;
                    row["Add"] = p.Add;
                    row["Del"] = p.Del;
                    row["Up"] = p.Up;
                    row["View"] = p.View;
                    dt.Rows.Add(row);
                }
                dataGridView3.DataSource = dt;
            }
            finally
            {
                dbConnect.db.Close();
            }
        }
        private void huyquyeng_Click_1(object sender, EventArgs e)
        {
            if (cgroup.Text.Trim() != "" && gthem.Text.Trim() != "")
            {
                qg.delquyen_group(cgroup.Text, cthem.Checked, cxoa.Checked, csua.Checked, cxem.Checked, gthem.Text);
                qu.capnhat_user_groupup(cgroup.Text.Trim(), gthem.Text.Trim());
                MessageBox.Show("Bạn đã hủy quyền nhóm thành công");
            }
            else
                MessageBox.Show("Bạn phải chọn Group và đối tượng muốn gán quyền");
        }

        private void themquyeng_Click(object sender, EventArgs e)
        {
            if (cgroup.Text.Trim() != "" && gthem.Text.Trim() != "")
            {
                qg.addquyen_group(cgroup.Text, cthem.Checked, cxoa.Checked, csua.Checked, cxem.Checked, gthem.Text);
                qu.capnhat_user_groupup(cgroup.Text.Trim(), gthem.Text.Trim());
                MessageBox.Show("Bạn đã thêm quyền nhóm thành công");
                refesh();
            }
            else
                MessageBox.Show("Bạn phải chọn Group và đối tượng muốn gán quyền");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                dbConnect.Open();
                List<Quyen_group> qg = new List<Quyen_group>();
                qg = (
                           from Quyen_group p in dbConnect.db
                           where p.Group == timgroup.Text
                           select p).ToList();
                dataGridView1.DataSource = qg;
            }
            finally
            {
                dbConnect.db.Close();
            }
        }

        private void addusernhom_Click(object sender, EventArgs e)
        {
            if (listug.Text.Trim() != "" && tgroup.Text.Trim() != "")
            {
                if (qu.taoquyen_user(listug.Text, tgroup.Text) == 1)
                    MessageBox.Show("Đã thêm vào nhóm thành công");
                else
                    MessageBox.Show("User đã được thêm vào nhóm này");
            }
            else MessageBox.Show("bạn phải chọn user và nhóm cần thêm");

        }
        private void xoausernhom_Click(object sender, EventArgs e)
        {
            if (listug.Text.Trim() != "" && tgroup.Text.Trim() != "")
            {
                if (qu.xoa_user(listug.Text, tgroup.Text) == 1)
                    MessageBox.Show("Đã xóa user khỏi nhóm thành công");
                else
                    MessageBox.Show("user này không có trong nhóm");
            }
            else MessageBox.Show("bạn phải chọn user và nhóm cần hủy");
        }

        private void cgroup_Click(object sender, EventArgs e)
        {
           
        }




    }
}

