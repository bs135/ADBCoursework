using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using LinqToExcel;
using System.Data;
using System.IO;
using OfficeOpenXml;
using OODBDemo.DBAccess;
using OODBDemo.Entities;
using OODBDemo.Utilities;
using System.Globalization;
namespace OODBDemo
{
    public class User
    {
        DBConnect dbConnect = new DBConnect();
        public string username;
        public string password;
        public string Password { get { return password; } set { password = value; } }
        public string Username { get { return username; } set { username = value; } }

        public void adduser(string nuser, string pass)
        {
            User themu = new User();
            themu.username = nuser;
            themu.Password = pass;
            try
            {

                dbConnect.Open();
                User g = (from User p in dbConnect.db
                          where p.username == nuser
                          select p).SingleOrDefault();
                if (g == null)
                { dbConnect.db.Store(themu); MessageBox.Show(" Đã tạo user thành công"); }
                else
                    MessageBox.Show("đã có user này");
            }
            finally
            {
                dbConnect.Close();
            }
        }
        public List<User> listuser()
        {
            try
            {
                List<User> g = new List<User>();
                dbConnect.Open();
                g = (from User p in dbConnect.db
                     select p).ToList();
                return g;
            }
            finally
            {
                dbConnect.Close();
            }
        }
        public User timuser(string tenuser)
        {
            try
            {

                dbConnect.Open();
                User g = (from User p in dbConnect.db
                          where p.username == tenuser
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
