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
namespace OODBDemo
{
    class Sinhvien : NguoiI
    {
        string malop;
        string bacdaotao;
        int khoahoc;
        string khoa;
        int cmnd;
        Checkinput chk = new Checkinput();
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
        public int Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }
        public void addsv(string ma, string hoten, string ngaysinh, string gioitinh
            , string diachi, int dienthoai, string malop, string bacdaotao, int khoahoc,string khoa,int cmnd)
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
            sv.Cmnd = cmnd;
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
               // if (chk.kiemtra_sinhvien(cmnd) == 0)
             //   {
                   // chk.kiemtratufile_excel(ref loi, ma, hoten, ngaysinh, gioitinh, diachi, dienthoai.ToString(), malop, bacdaotao, khoahoc.ToString(), khoa, cmnd.ToString());
                   // if (loi == "")
                        ketnoicsdl.db.Store(sv);
               // }
               // else loi += " Sinh viên " + ma + hoten + " này bạn đã thêm vào rồi vì số chứng minh của sinh viên này đã có trong hệ thống " + "\n";

                
            }
            finally
            {
               ketnoicsdl.db.Close();
            }
        }
        public void addsv_Luu(ref string loi,string ma, string hoten, string ngaysinh, string gioitinh
            , string diachi, int dienthoai, string malop, string bacdaotao, int khoahoc, string khoa, int cmnd)
        {
            Sinhvien sv = new Sinhvien();
            
             if (chk.kiemtra_sinhvien(cmnd) == 1)
               {
             chk.kiemtratufile_excel(ref loi, ma, hoten, ngaysinh, gioitinh, diachi, dienthoai.ToString(), malop, bacdaotao, khoahoc.ToString(), khoa, cmnd.ToString());
             if (loi == "")
                 sv.addsv(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, malop, bacdaotao, khoahoc, khoa, cmnd);
             }
             else loi += " Sinh viên " + ma + hoten + " này bạn đã thêm vào rồi vì số chứng minh hoặc mã sinh viên của sinh viên này đã có trong hệ thống " + "\n";

        }
        public void nhapsv_excel(ref string loi,string pathToExcelFile)
        {
            string sheetName = "Sheet1";
         
           
            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var docexcel = from a in excelFile.Worksheet<Sinhvien>(sheetName) select a;  
            foreach (var a in docexcel)
            {
                Sinhvien sv = new Sinhvien();
                if (chk.kiemtra_sinhvien(a.Cmnd) == 1)
               {
                    chk.kiemtratufile_excel(ref loi, a.Ma, a.Hoten, a.Ngaysinh, a.Gioitinh, a.Diachi, a.Dienthoai.ToString(), a.Malop, a.Bacdaotao, a.Khoahoc.ToString(), a.Khoa, a.Cmnd.ToString());
                   if (loi == "")
                        sv.addsv(a.Ma, a.Hoten, a.Ngaysinh, a.Gioitinh, a.Diachi, int.Parse(a.Dienthoai.ToString()), a.Malop, a.Bacdaotao, a.Khoahoc, a.Khoa, a.Cmnd);
                }
               else loi += " Sinh viên "+ a.Ma +a.Hoten +" này bạn đã thêm vào rồi vì số chứng minh của sinh viên này đã có trong hệ thống "+"\n";

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
                else if (chk.kiemtra_sinhvien_up(cmnd,ma) == 0)
                { 
                    MessageBox.Show("Số chứng minh này đã tồn tại trong hệ thống"); 
                
                }
                else

                {
                    svup[0].Hoten = hoten;
                    svup[0].Ngaysinh = ngaysinh;
                    svup[0].Diachi = diachi;
                    svup[0].Dienthoai = Convert.ToInt32(dienthoai);
                    svup[0].Malop = malop;
                    svup[0].Gioitinh = gioitinh;
                    svup[0].Khoahoc = Convert.ToInt32(khoahoc);
                    svup[0].Khoa = khoa;
                    ketnoicsdl.db.Store(svup);
                }
            }
            finally { ketnoicsdl.db.Close(); }
        }
        public List<Sinhvien> findsv(string masv,string makhoa,string malop)
        {
            List<Sinhvien> sv = new List<Sinhvien>();
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                try
                {
                    if (masv != "")
                    {
                        if (makhoa == "" && malop == "")
                            sv = (from Sinhvien p in ketnoicsdl.db
                                  where p.Ma == masv
                                  select p).ToList();
                        else
                            if (malop == "")
                                sv = (from Sinhvien p in ketnoicsdl.db
                                      where p.Ma == masv && p.khoa == makhoa
                                      select p).ToList();
                            else
                                if (makhoa == "")
                                    sv = (from Sinhvien p in ketnoicsdl.db
                                          where p.Ma == masv && p.malop == malop
                                          select p).ToList();
                                else
                                    sv = (from Sinhvien p in ketnoicsdl.db
                                          where p.Ma == masv && p.malop == malop && p.khoa == makhoa
                                          select p).ToList();
                    }
                    else
                    {
                        if (malop == "")
                            sv = (from Sinhvien p in ketnoicsdl.db
                                  where p.khoa == makhoa
                                  select p).ToList();
                        else
                            if (makhoa == "")
                                sv = (from Sinhvien p in ketnoicsdl.db
                                      where p.malop == malop
                                      select p).ToList();
                            else
                                sv = (from Sinhvien p in ketnoicsdl.db
                                      where  p.malop == malop && p.khoa == makhoa
                                      select p).ToList();
                    }
                    return sv;
                }
                catch { return null; }
            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
    }

}
