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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public Monhoc getById(string ma)
        {
            Monhoc obj = null;
            try
            {
                dbConnect.Open();
                obj = (from Monhoc p in dbConnect.db
                       where p.Mamh == ma
                       select p).FirstOrDefault();
                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }

            return obj;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Monhoc> getAll()
        {
            IList<Monhoc> list = new List<Monhoc>();
            try
            {
                dbConnect.Open();
                list = (from Monhoc p in dbConnect.db
                        select p).ToList();
                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }

            return list;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable getTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mamh");
            dt.Columns.Add("Tenmh");
            dt.Columns.Add("Sochi");
            IList<Monhoc> list = this.getAll();

            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["Mamh"] = item.Mamh;
                row["Tenmh"] = item.Tenmh;
                row["Sochi"] = item.Sochi;

                dt.Rows.Add(row);
            }

            return dt;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mamh"></param>
        /// <param name="tenmh"></param>
        /// <param name="sochi"></param>
        public void add(string mamh, string tenmh, int sochi)
        {
            Monhoc obj = new Monhoc();
            obj.Mamh = mamh;
            obj.Tenmh = tenmh;
            obj.Sochi = sochi;
            try
            {
                dbConnect.Open();
                dbConnect.db.Store(obj);
                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        public void delete(string ma)
        {
            try
            {
                dbConnect.Open();
                Monhoc obj = (from Monhoc p in dbConnect.db
                              where p.Mamh == ma
                              select p).FirstOrDefault();
                if (obj != null)
                {
                    dbConnect.db.Delete(obj);
                }

                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mamh"></param>
        /// <param name="tenmh"></param>
        /// <param name="sochi"></param>
        public void update(string mamh, string tenmh, int sochi)
        {
            try
            {
                dbConnect.Open();
                Monhoc obj = (from Monhoc p in dbConnect.db
                              where p.Mamh == mamh
                              select p).FirstOrDefault();
                if (obj != null)
                {
                    obj.Tenmh = tenmh;
                    obj.Sochi = sochi;

                    dbConnect.db.Store(obj);
                }

                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }

        }

    }
}
