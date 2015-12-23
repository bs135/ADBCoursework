using System;
using System.Collections.Generic;
using System.Text;
using Db4objects.Db4o;
using LinqToExcel;
using Db4objects.Db4o.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using OODBDemo.Entities;

namespace OODBDemo
{
    class ketnoicsdl
    {
        public static IObjectContainer db;
        public string DBPath { get; set; }

        public static IObjectContainer Opendb(string dl)
        {
            db = Db4oEmbedded.OpenFile(dl);
            return db;
        }

        public static string taomatudong(string tendoituong)
        {
            Opendb("c:\\oodb.db4o");
            string t = "";
            switch (tendoituong)
            {
                case "giaovien":
                    Khoa khoa = (from Khoa p in ketnoicsdl.db
                                 orderby p.Makhoa descending
                                 select p).FirstOrDefault();
                    if (khoa == null)//xem lai giao dien khoa 
                    {
                        t = " " + "00000001";
                    }
                    else
                    {
                        t = khoa.Makhoa.Substring(1, 4) + Int32.Parse(khoa.Makhoa.Substring(4, 8)) + 1;
                    }

                    break;
                case "sinhvien":
                    Sinhvien sv = (from Sinhvien p in ketnoicsdl.db
                                   orderby p.Ma descending
                                   select p).FirstOrDefault();
                    if (sv == null)
                    {
                        t = DateTime.Now.Year.ToString() + "00000001";
                    }
                    else
                    {
                        t = sv.Ma.Substring(1, 4) + Int32.Parse(sv.Ma.Substring(4, 8)) + 1;
                    }

                    break;
                case "lophoc":
                    Lop lop = (from Lop p in ketnoicsdl.db
                               orderby p.Malop descending
                               select p).FirstOrDefault();
                    if (lop == null)
                    {
                        t = "LH" + DateTime.Now.Year.ToString() + "000001";
                    }
                    else
                    {

                        t = lop.Malop.Substring(1, 6) + Int32.Parse(lop.Malop.Substring(4, 6)) + 1;
                    }

                    break;

                case "monhoc"://xem lai giao dien mon hoc roi lam
                    Monhoc mh = (from Monhoc p in ketnoicsdl.db
                                 orderby p.Mamh descending
                                 select p).FirstOrDefault();
                    if (mh == null)
                    {
                        t = "MH" + " " + "000001";
                    }
                    else
                    {
                        t = mh.Mamh.Substring(1, 6) + Int32.Parse(mh.Mamh.Substring(4, 6)) + 1;
                    }

                    break;

                /* case "khoa":
                      Khoa khoa = (from Khoa p in ketnoicsdl.db
                                    orderby p.Makhoa descending
                                    select p).FirstOrDefault();
                     if (khoa==null)
                     {
                         t = DateTime.Now.Year.ToString() + "00000001";
                     }
                     else
                     {
                         t =khoa.Makhoa.Substring(1,4)+ Int32.Parse(sv.Ma.Substring(4, 8))+1;
                     }
                   
                     break;*/


            }
            return t;
        }
        public static void laydskhoa()
        {


        }
        public static void laydslophoc_khoa()
        {
        }
        public static List<Khoa> laydsmonhoc_khoa()
        {
            try
            {
                Opendb("C:\\oodb.db4o");
                List<Khoa> dskhoa = (from Khoa p in ketnoicsdl.db
                                     select p).ToList();
                return dskhoa;
            }
            finally { db.Close(); }
        }
        public static void nganhhoc_khoa()
        {
            try
            {
                Opendb("C:\\oodb.db4o");
            }
            finally { db.Close(); }
        }
    }

}
