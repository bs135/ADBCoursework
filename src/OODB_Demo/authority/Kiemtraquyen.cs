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
    public class Kiemtraquyen
    {
        DBConnect dbConnect = new DBConnect();

        public Boolean kiemtraquyenuser(string user, string doituong, string quyen)
        {
            if (user.Trim() != "" && doituong.Trim() != "")
                try
                {
                    Boolean rbool, add, del, view, up;
                    rbool = false; add = false; del = false; view = false; up = false;

                    List<Quyen_user> quser = new List<Quyen_user>();
                    dbConnect.Open();
                    quser = (from Quyen_user p in dbConnect.db
                             where p.User.ToLower() == user.ToLower() && p.doituong.ToLower() == doituong.ToLower()
                             select p).ToList();
                    if (quser.Count > 0)
                    {
                        for (int i = 0; i < quser.Count; i++)
                        {
                            add = add || quser[i].Add;
                            del = del || quser[i].Del;
                            up = up || quser[i].Up;
                            view = view || quser[i].View;
                        }
                        switch (quyen)
                        {
                            case "add":
                                rbool = add; break;
                            case "del":
                                rbool = del; break;
                            case "up":
                                rbool = up; break;
                            case "view":
                                rbool = view; break;
                            case "module":
                                rbool = add || del || up || view; break;
                        }
                    }
                    return rbool;
                }
                finally
                {
                    dbConnect.Close();
                }

            else return false;
        }
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
        //kiem tra cac thuoc tinh cua doi tuong bi ngan cam quyen xem

    }

}
