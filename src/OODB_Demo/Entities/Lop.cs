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
    public class Lop
    {
        public string Malop { get; set; }
        public string Tenlop { get; set; }
        public string Makhoa { get; set; }

        public void addlop(string malop,string tenlop,string makhoa)
        {
            Lop lop = new Lop();
            lop.Malop = malop;
            lop.Tenlop = tenlop;
            lop.Makhoa = makhoa;
            
            try
            {
                ketnoicsdl.Opendb(ketnoicsdl._db_path);
                ketnoicsdl.db.Store(lop);
            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        
        }

        public Lop findlop(string malop)
        {
            Lop lop = new Lop();
            try
            {
                ketnoicsdl.Opendb(ketnoicsdl._db_path);

                lop = (from Lop p in ketnoicsdl.db
                       where p.Malop == malop
                      select p).SingleOrDefault();
                return lop;
            }
            finally
            {
                ketnoicsdl.db.Close();
            }

        }
        public List<Lop> listlop_khoa(string khoa)
        {
            List<Lop> kh = new List<Lop>();
            try
            {
                ketnoicsdl.Opendb(ketnoicsdl._db_path);

                kh = (from Lop p in ketnoicsdl.db
                      where p.Makhoa==khoa
                      select p).ToList();
                return kh;
            }
            finally
            {
                ketnoicsdl.db.Close();
            }

        }

    }
}
