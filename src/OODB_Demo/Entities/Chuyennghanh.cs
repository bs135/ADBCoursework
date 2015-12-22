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
    class Chuyennghanh
    {
        string manghanh;
        string tennghanh;
        string makhoa;
        public string Manghanh
        {
            get { return manghanh; }
            set { manghanh = value; }
        }
        public string Tennghanh
        {
            get { return tennghanh; }
            set { tennghanh = value; }
        }
        public string Makhoa
        {
            get { return makhoa; }
            set { makhoa = value; }
        }

        public List<Chuyennghanh> listnghanh_khoa(string khoa)
        {
            List<Chuyennghanh> cn = new List<Chuyennghanh>();
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                cn = (from Chuyennghanh p in ketnoicsdl.db
                      where p.makhoa == khoa
                      select p).ToList();
                return cn;
            }
            finally
            {
                ketnoicsdl.db.Close();
            }

        }
    }
}
