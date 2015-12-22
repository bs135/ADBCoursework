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
    class Sinhvien : NguoiI
    {
        string malop;
        string bacdaotao;
        int khoahoc;
        string khoa;
        string nganhhoc;
        public string Malop
        {
            get { return malop; }
            set { malop = value; }
        }
        public string Bacdaotao
        {
            get { return bacdaotao; }
            set { bacdaotao = value; }
        }
        public int  Khoahoc
        {
            get { return khoahoc; }
            set { khoahoc = value; }
        }
        public string Khoa
        {
            get { return khoa; }
            set { khoa = value; }
        }
        public string Nganhhoc
        {
            get { return nganhhoc; }
            set { nganhhoc = value; }
        }
        public void addsv(string ma, string hoten, string ngaysinh, string gioitinh
            , string diachi, int dienthoai, string malop, string bacdaotao, int khoahoc,string khoa,string nghanhhoc)
        {
            Sinhvien sv = new Sinhvien();
            sv.Ma = ma;
            sv.Hoten = hoten;
            sv.Ngaysinh = ngaysinh;
            sv.Gioitinh = gioitinh;
            sv.Diachi = diachi;
            sv.Dienthoai = dienthoai;
            sv.Malop = malop;
            sv.Bacdaotao = bacdaotao;
            sv.Khoahoc = khoahoc;
            sv.Khoa = khoa;
            sv.Nganhhoc = nghanhhoc;
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");              
                ketnoicsdl.db.Store(sv);
            }
            finally
            {
               ketnoicsdl.db.Close();
            }
        }
        public void nhapsv_excel(ref string loi,string pathToExcelFile)
        {
            string sheetName = "Sheet1";
         
            Checkinput chk = new Checkinput();
            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var docexcel = from a in excelFile.Worksheet<Sinhvien>(sheetName) select a;  
            foreach (var a in docexcel)
            {
                Sinhvien sv = new Sinhvien();
                chk.kiemtratufile_excel(ref loi,a.Ma, a.Hoten, a.Ngaysinh, a.Gioitinh, a.Diachi, a.Dienthoai.ToString(), a.Malop, a.Bacdaotao, a.Khoahoc.ToString(), a.Khoa, a.Nganhhoc);
                if(loi=="")
                sv.addsv(a.Ma, a.Hoten, a.Ngaysinh, a.Gioitinh, a.Diachi, int.Parse(a.Dienthoai.ToString()), a.Malop, a.Bacdaotao, a.Khoahoc, a.Khoa, a.Nganhhoc);
                 
            }
           
        }
        public int xoasv(string  ma)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                Sinhvien svdel = (from Sinhvien p in ketnoicsdl.db
                                  where p.Ma == ma
                                  select p).SingleOrDefault();
                if (svdel != null)
                {
                    ketnoicsdl.db.Delete(svdel);
                }
            }
            finally
            {
                ketnoicsdl.db.Close();
            }
            return 0;
        }
        public void updatesv(string ma, string hoten, string ngaysinh, string diachi, string gioitinh,
            string dienthoai,string malop,string khoahoc,string khoa,string nganhhoc)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                List<Sinhvien> svup = (from Sinhvien p in ketnoicsdl.db
                                       where p.Ma == ma
                                       select p).ToList();
                if (svup.Count>1)
                {
                    MessageBox.Show("mã sinh viên này bị trùng lặp trong hệ thống");
                }
                else
                {
                    svup[1].Hoten = hoten;
                    svup[1].Ngaysinh = ngaysinh;
                    svup[1].Diachi = diachi;
                    svup[1].Dienthoai = Convert.ToInt32(dienthoai);
                    svup[1].Malop = malop;
                    svup[1].Gioitinh = gioitinh;
                    svup[1].Khoahoc = Convert.ToInt32(khoahoc);
                    svup[1].Khoa = khoa;
                    svup[1].Nganhhoc = nganhhoc;
                    ketnoicsdl.db.Store(svup);
                }
            }
            finally { ketnoicsdl.db.Close(); }
        }
        public Sinhvien findsv(string masv)
        {
            Sinhvien sv = new Sinhvien();
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");

                sv = (from Sinhvien p in ketnoicsdl.db
                                  where p.Ma == masv
                                  select p).SingleOrDefault();    
                    return sv;
            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
    }

}
