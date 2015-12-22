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
    class Lop
    {
        string malop;
        string tenlop;
        string makhoa;
        string manghanh;
        public string Malop
        {
            get { return malop; }
            set { malop = value; }
        }
        public string Tenlop
        {
            get { return tenlop; }
            set { tenlop = value; }
        }
        public string Makhoa
        { 
            get { return makhoa; }
            set { makhoa=value; }
        }
        public string Manghanh
        {
            get { return manghanh; }
            set { manghanh = value; }
        }
        public void addlop(string malop,string tenlop,string makhoa,string manghanh)
        {
            Lop lop = new Lop();
            lop.Malop = malop;
            lop.tenlop = tenlop;
            lop.Makhoa = makhoa;
            lop.manghanh = manghanh;
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                ketnoicsdl.db.Store(lop);
            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        
        }
        public void updatelop()
        {
            

        }
        public void dellop()
        {


        }
        public Lop findlop(string malop)
        {
            Lop lop = new Lop();
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                lop = (from Lop p in ketnoicsdl.db
                       where p.malop == malop
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
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                kh = (from Lop p in ketnoicsdl.db
                      where p.makhoa==khoa
                      select p).ToList();
                return kh;
            }
            finally
            {
                ketnoicsdl.db.Close();
            }

        }
        public List<Lop> listlop_nghanh(string manghanh)
        {
            List<Lop> kh = new List<Lop>();
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                kh = (from Lop p in ketnoicsdl.db
                      where p.manghanh == manghanh
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
