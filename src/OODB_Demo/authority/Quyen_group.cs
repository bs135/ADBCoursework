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
    public class Quyen_group
    {
        public Boolean up;
        public Boolean view;
        public Boolean add;
        public Boolean del;
        public string group;
        public string doituong;
        public Boolean Up { get { return up; } set { up = value; } }
        public Boolean View { get { return view; } set { view = value; } }
        public Boolean Add { get { return add; } set { add = value; } }
        public Boolean Del { get { return del; } set { del = value; } }
        public string Group { get { return group; } set { group = value; } }
        public string Doituong { get { return doituong; } set { doituong = value; } }
        DBConnect dbConnect = new DBConnect();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        /// <param name="add"></param>
        /// <param name="del"></param>
        /// <param name="up"></param>
        /// <param name="view"></param>
        /// <param name="doituong"></param>
        /// <returns></returns>
        public int addquyen_group(string groupname, Boolean add, Boolean del, Boolean up, Boolean view, string doituong)//khi tao moi thi kiem tra 
        {
            try
            {

                dbConnect.Open();
                Quyen_group listgroup = (from Quyen_group p in dbConnect.db
                                         where p.Group == groupname && p.Doituong == doituong
                                         select p).SingleOrDefault();
                if (listgroup != null)
                {
                    listgroup.Add = add;
                    listgroup.Del = del;
                    listgroup.Up = up;
                    listgroup.View = view;
                    listgroup.Group = groupname;
                    listgroup.Doituong = doituong;
                    dbConnect.db.Store(listgroup);
                }
                else
                {
                    Quyen_group group = new Quyen_group();
                    group.Add = add;
                    group.Del = del;
                    group.Up = up;
                    group.View = view;
                    group.Group = groupname;
                    group.Doituong = doituong;
                    dbConnect.db.Store(group);
                }
                return 1;

            }
            catch { return 0; }
            finally
            {
                dbConnect.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        /// <param name="add"></param>
        /// <param name="del"></param>
        /// <param name="up"></param>
        /// <param name="view"></param>
        /// <param name="doituong"></param>
        /// <returns></returns>
        public int delquyen_group(string groupname, Boolean add, Boolean del, Boolean up, Boolean view, string doituong)//khi tao moi thi kiem tra 
        {
            try
            {
                Quyen_group listgroup = new Quyen_group();
                dbConnect.Open();
                listgroup = (from Quyen_group p in dbConnect.db
                             where p.Group == groupname && p.Doituong == doituong
                             select p).SingleOrDefault();

                if (listgroup != null)
                {
                    listgroup.Add = add;
                    listgroup.Del = del;
                    listgroup.Up = up;
                    listgroup.View = view;
                    dbConnect.db.Store(listgroup);
                }

                return 1;
            }
            catch { return 0; }
            finally
            {
                dbConnect.Close();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupname"></param>
        /// <param name="doituong"></param>
        /// <returns></returns>
        public Quyen_group timquyen_group(string groupname, string doituong)
        {
            try
            {
                Quyen_group listgroup = new Quyen_group();
                dbConnect.Open();
                listgroup = (from Quyen_group p in dbConnect.db
                             where p.Group == groupname && p.Doituong == doituong
                             select p).SingleOrDefault();
                if (listgroup != null)
                    return listgroup;
                else return null;
            }
            catch { return null; }
            finally
            {
                dbConnect.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> listgroup()
        {
            try
            {
                List<string> listgroup = new List<string>();
                dbConnect.Open();
                var list = (from Quyen_group p in dbConnect.db
                            group p by p.Group into g
                            select new { Group = g.Key });
                foreach (var p in list)
                    listgroup.Add(p.Group);
                return listgroup;
            }
            catch { return null; }
            finally
            {
                dbConnect.Close();
            }

        }
    }
}
