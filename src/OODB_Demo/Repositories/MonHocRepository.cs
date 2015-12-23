using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using LinqToExcel;
using System.Data;
using OODBDemo.DBAccess;
using OODBDemo.Entities;

namespace OODBDemo.Repositories
{
    public class MonHocRepository
    {
        DBConnect dbConnect = new DBConnect();

        public Monhoc getById(string id)
        {
            Monhoc mh = null;
            try
            {
                dbConnect.Open();
                mh = (from Monhoc p in dbConnect.db
                      where p.Mamh == id
                      select p).FirstOrDefault();
                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return mh;
        }

        public IList<Monhoc> getAll()
        {
            IList<Monhoc> listmh = new List<Monhoc>();
            try
            {
                dbConnect.Open();
                listmh = (from Monhoc p in dbConnect.db
                          select p).ToList();
                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return listmh;

        }

        public DataTable getTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MMH");
            dt.Columns.Add("Tên môn học");
            dt.Columns.Add("Số chỉ");
            IList<Monhoc> list = this.getAll();

            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["MMH"] = item.Mamh;
                row["Tên môn học"] = item.Tenmh;
                row["Số chỉ"] = item.Sochi;

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
