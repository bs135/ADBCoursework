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
    public class Quyen_user
    {
        public Boolean add;
        public Boolean del;
        public Boolean view;
        public Boolean up;
        public string user;
        public string doituong;
        public string group;
        public Boolean Add { get { return add; } set { add = value; } }
        public Boolean Del { get { return del; } set { del = value; } }
        public Boolean View { get { return view; } set { view = value; } }
        public Boolean Up { get { return up; } set { up = value; } }
        public string User { get { return user; } set { user = value; } }
        public string Doituong { get { return doituong; } set { doituong = value; } }
        public string Group { get { return group; } set { group = value; } }
        DBConnect dbConnect = new DBConnect();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuser"></param>
        /// <param name="user"></param>
        /// <param name="groupname"></param>
        /// <returns></returns>
        public int kiemtrauser_group(Quyen_user cuser, string user, string groupname)//khi tao moi thi kiem tra
        {
            try
            {
                List<Quyen_user> quser = new List<Quyen_user>();
                dbConnect.Open();
                quser = (from Quyen_user p in dbConnect.db
                         where p.User == user && p.Group == groupname
                         select p).ToList();
                if (quser.Count > 0)
                    return 0;
                else
                { dbConnect.db.Store(cuser); ;return 1; }

            }
            finally
            {
                dbConnect.Close();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="groupn"></param>
        /// <returns></returns>
        public int xoa_user(string user, string groupn)
        {
            try
            {
                List<Quyen_user> quser = new List<Quyen_user>();
                dbConnect.Open();
                quser = (from Quyen_user p in dbConnect.db
                         where p.User == user && p.Group == groupn
                         select p).ToList();
                if (quser != null || quser.Count > 0)
                {
                    for (int i = 0; i < quser.Count; i++)
                        dbConnect.db.Delete(quser[i]);
                    return 1;
                }
                else return 0;

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
        /// <param name="user"></param>
        /// <param name="groupn"></param>
        /// <returns></returns>
        public int taoquyen_user(string user, string groupn)//them user vao nhom
        {
            try
            {

                dbConnect.Open();
                Quyen_user quser = (from Quyen_user p in dbConnect.db
                                    where p.User == user && p.Group == groupn
                                    select p).SingleOrDefault();

                if (quser != null)
                    return 0;
                else
                {

                    //chi nhung group da dc them quyen moi gan cho user
                    var tdtgroup = (from Quyen_group p in dbConnect.db
                                    where p.Group == groupn
                                    select new { p.Doituong, p.Add, p.Del, p.Up, p.View });
                    if (tdtgroup != null)
                        foreach (var item in tdtgroup)
                        {
                            Quyen_user newu = new Quyen_user();
                            newu.User = user;
                            newu.Doituong = item.Doituong;
                            newu.Add = item.Add;
                            newu.Del = item.Del;
                            newu.Up = item.Up;
                            newu.View = item.View;
                            newu.Group = groupn;
                            dbConnect.db.Store(newu);
                        }
                    return 1;
                }
            }
            catch { return 0; }
            finally
            {
                dbConnect.Close();
            }

        }
        public void capnhat_user_groupup(string tengroup, string doituong)
        {

            try
            {

                dbConnect.Open();
                List<Quyen_user> quser = (from Quyen_user p in dbConnect.db
                                          where p.Group == tengroup
                                          select p).ToList();

                if (quser != null)
                {
                    //chi nhung group da dc them quyen moi gan cho user
                    Quyen_user kt = (from Quyen_user p in dbConnect.db
                                     where  p.Group == tengroup && p.Doituong == doituong
                                     select p).FirstOrDefault();
                    Quyen_group tdtgroup = (from Quyen_group p in dbConnect.db
                                            where p.Group == tengroup && p.Doituong == doituong
                                            select p).FirstOrDefault();

                    if (tdtgroup != null && kt != null)
                        foreach (var i in quser)
                        {
                            i.Add = tdtgroup.Add;
                            i.Del = tdtgroup.Del;
                            i.Up = tdtgroup.Up;
                            i.View = tdtgroup.View;
                            dbConnect.db.Store(i);
                        }
                    else if (kt == null )
                    {
                        foreach (var i in quser)
                        {
                            Quyen_user adduser = new Quyen_user();
                            adduser.User = i.User;
                            adduser.Group = tengroup;
                            adduser.Doituong = tdtgroup.Doituong;
                            adduser.Add = tdtgroup.Add;
                            adduser.Del = tdtgroup.Del;
                            adduser.Up = tdtgroup.Up;
                            adduser.View = tdtgroup.View;
                            dbConnect.db.Store(adduser);
                        }

                    }
                }
            }
            catch { }
            finally
            {
                dbConnect.Close();
            }


        }
    }
}
