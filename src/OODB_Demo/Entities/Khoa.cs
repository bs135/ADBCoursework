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
    class Khoa
    {
        string makhoa;
        string tenkhoa;
        string truongkhoa;
        string photruongkhoa;
        string email;
        string dienthoai;
        string diachi;
        public string Makhoa
        {
            get { return makhoa; }
            set { makhoa = value; }
        }
        public string Tenkhoa
        {
            get { return tenkhoa; }
            set { tenkhoa = value; }
        }
        public string Truongkhoa
        {
            get { return truongkhoa; }
            set { truongkhoa = value; }
        }
        public string Photruongkhoa
        {
            get { return photruongkhoa; }
            set { photruongkhoa = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public string Dienthoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }
        public void addkhoa(string makhoa,string tenkhoa,string truongkhoa,string phokhoa,string email,string dienthoai,string diachi)
        {
            Khoa kh = new Khoa();
            kh.Makhoa = makhoa;
            kh.Tenkhoa = tenkhoa;
            kh.Truongkhoa = truongkhoa;
            kh.Photruongkhoa = phokhoa;
            kh.Email = email;
            kh.Dienthoai = dienthoai;
            kh.Diachi = diachi;
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                ketnoicsdl.db.Store(kh);
            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
        public void updatekhoa()
        { 
        
        }
        public void delkhoa()
        { 
        
        }
        public Khoa findkhoa(string makhoa)
        {
            Khoa kh = new Khoa();
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                kh = (from Khoa p in ketnoicsdl.db
                      where p.makhoa == makhoa
                      select p).SingleOrDefault();
                return kh;
            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        
        }
        public List<Khoa> listkhoa()
        {
           List<Khoa> kh = new List<Khoa>();
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                kh = (from Khoa p in ketnoicsdl.db
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
