using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using LinqToExcel;
using System.Globalization;
using System.Windows.Forms;
namespace OODBDemo
{
    class User : NguoiI
    {

        public User find(string ma)
        {
            User user = new User();
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                user = (from User p in ketnoicsdl.db
                        where p.Ma == ma
                        select p).SingleOrDefault();
                return user;
            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
    }
}
