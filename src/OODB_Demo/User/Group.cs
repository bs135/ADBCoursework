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
using OODBDemo.DBAccess;
namespace OODBDemo
{
    public class Group
    {
        DBConnect dbConnect = new DBConnect();
        public string namegroup;
        public String Namegroup { get { return namegroup; } set { namegroup=value; } }
        public  void addgroup(string ngroup)
        {
            Group themg = new Group();
            themg.Namegroup = ngroup;
            try
            {
              
                dbConnect.Open();
             Group   g = (from Group p in dbConnect.db
                             where p.Namegroup == ngroup
                             select p).SingleOrDefault();
                if (g == null)
                { dbConnect.db.Store(themg); MessageBox.Show(" Đã tạo group thành công"); }
                else
                    MessageBox.Show("đã có group này");
            }
            finally
            {
                dbConnect.Close();
            }
        }
        public List<Group> listgroup()
        {
            try
            {
                List<Group> g = new List<Group>();
                dbConnect.Open();
                g = (from Group p in dbConnect.db
                     select p).ToList();
                return g;
            }
            finally
            {
                dbConnect.Close();
            }
        }
        public Group timgroup(string tengroup,string tendoituong)
        {
            try
            {

                dbConnect.Open();
                Group g = (from Group p in dbConnect.db
                           where p.Namegroup == tengroup 
                           select p).SingleOrDefault();
                return g;
            }
            finally
            {
                dbConnect.Close();
            }
        }
    }
}
