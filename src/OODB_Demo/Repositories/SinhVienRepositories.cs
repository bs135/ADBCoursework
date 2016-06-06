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
using OODBDemo.Entities;
namespace OODBDemo.Repositories
{
    public class SinhVienRepositories
    {
        DBConnect dbConnect = new DBConnect();
        Checkinput chk = new Checkinput();
        public void addsv(string ma, string hoten, string ngaysinh, string gioitinh
    , string diachi, string dienthoai, string malop, string bacdaotao, int khoahoc, string khoa, string cmnd)
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
                dbConnect.Open();
                // if (chk.kiemtra_sinhvien(cmnd) == 0)
                //   {
                // chk.kiemtratufile_excel(ref loi, ma, hoten, ngaysinh, gioitinh, diachi, dienthoai.ToString(), malop, bacdaotao, khoahoc.ToString(), khoa, cmnd.ToString());
                // if (loi == "")
                dbConnect.db.Store(sv);
                // }
                // else loi += " Sinh viên " + ma + hoten + " này bạn đã thêm vào rồi vì số chứng minh của sinh viên này đã có trong hệ thống " + "\n";


            }
            finally
            {
                dbConnect.Close();
            }
        }
        public void addsv_Luu(ref string loi, string ma, string hoten, string ngaysinh, string gioitinh
            , string diachi, string dienthoai, string malop, string bacdaotao, int khoahoc, string khoa, int cmnd)
        {


            if (chk.kiemtra_sinhvien(cmnd.ToString()) == 1)
            {
                chk.kiemtratufile_excel(ref loi, ma, hoten, ngaysinh, gioitinh, diachi, dienthoai.ToString(), malop, bacdaotao, khoahoc.ToString(), khoa, cmnd.ToString());
                if (loi == "")
                    addsv(ma, hoten, ngaysinh, gioitinh, diachi, dienthoai, malop, bacdaotao, khoahoc, khoa, cmnd.ToString());
            }
            else loi += " Sinh viên " + ma + hoten + " này bạn đã thêm vào rồi vì số chứng minh hoặc mã sinh viên của sinh viên này đã có trong hệ thống " + "\n";

        }
        public void nhapsv_excel(ref string loi, string pathToExcelFile)
        {
            string sheetName = "Sheet1";
            string masv = "";

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var docexcel = from a in excelFile.Worksheet<Sinhvien>(sheetName) select a;
            foreach (var a in docexcel)
            {
                if (chk.kiemtra_sinhvien(a.Cmnd) == 1)
                {
                    chk.kiemtratufile_excel(ref loi, masv, a.Hoten, a.Ngaysinh, a.Gioitinh, a.Diachi, a.Dienthoai.ToString(), a.Malop, a.Bacdaotao, a.Khoahoc.ToString(), a.Khoa, a.Cmnd.ToString());
                    if (loi == "")
                    {
                        masv = ketnoicsdl.taomatudong("sinhvien");
                        addsv(masv, a.Hoten, a.Ngaysinh, a.Gioitinh, a.Diachi, a.Dienthoai.ToString(), a.Malop, a.Bacdaotao, a.Khoahoc, a.Khoa, a.Cmnd);
                    }
                }
                else loi += " Sinh viên " + a.Hoten + " này bạn đã thêm vào rồi vì số chứng minh của sinh viên này đã có trong hệ thống " + "\n";

            }

        }
        public int xoasv(string ma)
        {
            try
            {
                dbConnect.Open();

                Sinhvien svdel = (from Sinhvien p in dbConnect.db
                                  where p.Ma == ma
                                  select p).SingleOrDefault();
                if (svdel != null)
                {
                    dbConnect.db.Delete(svdel);
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
        public int updatesv(string ma, string hoten, string ngaysinh, string diachi, string gioitinh,
             string dienthoai, string malop, string khoahoc, string khoa, string bacdaotao, string cmnd)
        {
            try
            {
                dbConnect.Open();
                Sinhvien svup = (from Sinhvien p in dbConnect.db
                                 where p.Ma == ma
                                 select p).FirstOrDefault();
                if (svup != null)
                {
                    svup.Hoten = hoten;
                    svup.Ngaysinh = ngaysinh;
                    svup.Diachi = diachi;
                    svup.Dienthoai = dienthoai;
                    svup.Malop = malop;
                    svup.Gioitinh = gioitinh;
                    svup.Khoahoc = Convert.ToInt32(khoahoc);
                    svup.Bacdaotao = bacdaotao;
                    svup.Khoa = khoa;
                    svup.Cmnd = cmnd;
                    dbConnect.db.Store(svup);
                }
                return 1;
            }
            catch { return 0; }
            finally { dbConnect.Close(); }
        }
        public List<Sinhvien> findsv(string masv, string makhoa, string malop)
        {
            List<Sinhvien> sv = new List<Sinhvien>();
            try
            {
                dbConnect.Open();
                try
                {
                    if (masv != "")
                    {
                        if (makhoa == "" && malop == "")
                        {
                            {
                                var sva = (from Sinhvien p in dbConnect.db
                                           join Khoa k in dbConnect.db
                                           on p.Khoa equals k.Makhoa

                                           where p.Ma == masv
                                           select new { p.Ma, p.Bacdaotao, p.Cmnd, p.Diachi, p.Dienthoai, p.Gioitinh, p.Hoten, k.Tenkhoa, p.Khoahoc, p.Malop, p.Ngaysinh });
                                foreach (var p in sva)
                                {
                                    Sinhvien s = new Sinhvien();
                                    s.Ma = p.Ma;
                                    s.Bacdaotao = p.Bacdaotao;
                                    s.Cmnd = p.Cmnd;
                                    s.Diachi = p.Diachi;
                                    s.Dienthoai = p.Dienthoai;
                                    s.Gioitinh = p.Gioitinh;
                                    s.Hoten = p.Hoten;
                                    s.Khoa = p.Tenkhoa;
                                    s.Khoahoc = p.Khoahoc;
                                    s.Malop = p.Malop;
                                    s.Ngaysinh = p.Ngaysinh;
                                    sv.Add(s);
                                }
                            }
                            //  sv1.ToList();
                        }
                        else
                            if (malop == "")
                            {
                                var sva = (from Sinhvien p in dbConnect.db
                                           join Khoa k in dbConnect.db
                                           on p.Khoa equals k.Makhoa
                                           where p.Ma == masv && p.Khoa == makhoa
                                           select new { p.Ma, p.Bacdaotao, p.Cmnd, p.Diachi, p.Dienthoai, p.Gioitinh, p.Hoten, k.Tenkhoa, p.Khoahoc, p.Malop, p.Ngaysinh });
                                foreach (var p in sva)
                                {
                                    Sinhvien s = new Sinhvien();
                                    s.Ma = p.Ma;
                                    s.Bacdaotao = p.Bacdaotao;
                                    s.Cmnd = p.Cmnd;
                                    s.Diachi = p.Diachi;
                                    s.Dienthoai = p.Dienthoai;
                                    s.Gioitinh = p.Gioitinh;
                                    s.Hoten = p.Hoten;
                                    s.Khoa = p.Tenkhoa;
                                    s.Khoahoc = p.Khoahoc;
                                    s.Malop = p.Malop;
                                    s.Ngaysinh = p.Ngaysinh;
                                    sv.Add(s);
                                }
                            }
                            else
                                if (makhoa == "")
                                {
                                    var sva = (from Sinhvien p in dbConnect.db
                                               join Khoa k in dbConnect.db
                                               on p.Khoa equals k.Makhoa
                                               where p.Ma == masv && p.Malop == malop
                                               select new { p.Ma, p.Bacdaotao, p.Cmnd, p.Diachi, p.Dienthoai, p.Gioitinh, p.Hoten, k.Tenkhoa, p.Khoahoc, p.Malop, p.Ngaysinh });
                                    foreach (var p in sva)
                                    {
                                        Sinhvien s = new Sinhvien();
                                        s.Ma = p.Ma;
                                        s.Bacdaotao = p.Bacdaotao;
                                        s.Cmnd = p.Cmnd;
                                        s.Diachi = p.Diachi;
                                        s.Dienthoai = p.Dienthoai;
                                        s.Gioitinh = p.Gioitinh;
                                        s.Hoten = p.Hoten;
                                        s.Khoa = p.Tenkhoa;
                                        s.Khoahoc = p.Khoahoc;
                                        s.Malop = p.Malop;
                                        s.Ngaysinh = p.Ngaysinh;
                                        sv.Add(s);
                                    }

                                }
                                else
                                {
                                    var sva = (from Sinhvien p in dbConnect.db
                                               join Khoa k in dbConnect.db
                                               on p.Khoa equals k.Makhoa
                                               where p.Ma == masv && p.Malop == malop && p.Khoa == makhoa
                                               select new { p.Ma, p.Bacdaotao, p.Cmnd, p.Diachi, p.Dienthoai, p.Gioitinh, p.Hoten, k.Tenkhoa, p.Khoahoc, p.Malop, p.Ngaysinh });
                                    foreach (var p in sva)
                                    {
                                        Sinhvien s = new Sinhvien();
                                        s.Ma = p.Ma;
                                        s.Bacdaotao = p.Bacdaotao;
                                        s.Cmnd = p.Cmnd;
                                        s.Diachi = p.Diachi;
                                        s.Dienthoai = p.Dienthoai;
                                        s.Gioitinh = p.Gioitinh;
                                        s.Hoten = p.Hoten;
                                        s.Khoa = p.Tenkhoa;
                                        s.Khoahoc = p.Khoahoc;
                                        s.Malop = p.Malop;
                                        s.Ngaysinh = p.Ngaysinh;
                                        sv.Add(s);
                                    }

                                }
                    }
                    else
                    {
                        if (malop == "")
                        {
                            var sva = (from Sinhvien p in dbConnect.db
                                       join Khoa k in dbConnect.db
                                        on p.Khoa equals k.Makhoa
                                       where p.Khoa == makhoa
                                       select new { p.Ma, p.Bacdaotao, p.Cmnd, p.Diachi, p.Dienthoai, p.Gioitinh, p.Hoten, k.Tenkhoa, p.Khoahoc, p.Malop, p.Ngaysinh });
                            foreach (var p in sva)
                            {
                                Sinhvien s = new Sinhvien();
                                s.Ma = p.Ma;
                                s.Bacdaotao = p.Bacdaotao;
                                s.Cmnd = p.Cmnd;
                                s.Diachi = p.Diachi;
                                s.Dienthoai = p.Dienthoai;
                                s.Gioitinh = p.Gioitinh;
                                s.Hoten = p.Hoten;
                                s.Khoa = p.Tenkhoa;
                                s.Khoahoc = p.Khoahoc;
                                s.Malop = p.Malop;
                                s.Ngaysinh = p.Ngaysinh;
                                sv.Add(s);
                            }
                        }

                        else
                            if (makhoa == "")
                            {
                                var sva = (from Sinhvien p in dbConnect.db
                                           join Khoa k in dbConnect.db
                                            on p.Khoa equals k.Makhoa
                                           where p.Malop == malop
                                           select new { p.Ma, p.Bacdaotao, p.Cmnd, p.Diachi, p.Dienthoai, p.Gioitinh, p.Hoten, k.Tenkhoa, p.Khoahoc, p.Malop, p.Ngaysinh });
                                foreach (var p in sva)
                                {
                                    Sinhvien s = new Sinhvien();
                                    s.Ma = p.Ma;
                                    s.Bacdaotao = p.Bacdaotao;
                                    s.Cmnd = p.Cmnd;
                                    s.Diachi = p.Diachi;
                                    s.Dienthoai = p.Dienthoai;
                                    s.Gioitinh = p.Gioitinh;
                                    s.Hoten = p.Hoten;
                                    s.Khoa = p.Tenkhoa;
                                    s.Khoahoc = p.Khoahoc;
                                    s.Malop = p.Malop;
                                    s.Ngaysinh = p.Ngaysinh;
                                    sv.Add(s);
                                }
                            }
                            else
                            {

                                var sva = (from Sinhvien p in dbConnect.db
                                           join Khoa k in dbConnect.db
                                            on p.Khoa equals k.Makhoa
                                           where p.Malop == malop && p.Khoa == makhoa
                                           select new { p.Ma, p.Bacdaotao, p.Cmnd, p.Diachi, p.Dienthoai, p.Gioitinh, p.Hoten, k.Tenkhoa, p.Khoahoc, p.Malop, p.Ngaysinh });
                                foreach (var p in sva)
                                {
                                    Sinhvien s = new Sinhvien();
                                    s.Ma = p.Ma;
                                    s.Bacdaotao = p.Bacdaotao;
                                    s.Cmnd = p.Cmnd;
                                    s.Diachi = p.Diachi;
                                    s.Dienthoai = p.Dienthoai;
                                    s.Gioitinh = p.Gioitinh;
                                    s.Hoten = p.Hoten;
                                    s.Khoa = p.Tenkhoa;
                                    s.Khoahoc = p.Khoahoc;
                                    s.Malop = p.Malop;
                                    s.Ngaysinh = p.Ngaysinh;
                                    sv.Add(s);
                                }
                            }
                    }
                    return sv;
                }
                catch { return null; }
            }
            finally
            {
                dbConnect.Close();
            }
        }
    }
}
