using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o.Linq;
using LinqToExcel;
using System.Globalization;
using System.Text.RegularExpressions;
namespace courcework
{
    class Checkinput
    {
        public int kiemtragiatrirong(string giatri)
        {
            if (giatri.Trim() == "")
                return 1;
            else return 0;
        
        }
        public string kiemtranull(object c)
        {
            if (c ==null)
                return "";
            else return c.ToString();
        }
        public int kiemtrangay(string ngay)
        {
            DateTime Test;
            if (DateTime.TryParse(ngay, out Test))
            {
               return 1; // MessageBox.Show(Test.ToString());
            }
            else
            { return 0; }
           
        }
        //tat cac cac ma:nguoi,gv,sinhvien,monhoc
        public void kiemtra_ma(int ma)
        { 
        
        }
        public int kiemtra_dienthoai(String dienthoai)
        {
            Regex regex = new Regex(@"[0-9]+");
            if (regex.IsMatch(dienthoai) == true && (dienthoai.Length >= 9 && dienthoai.Length <= 10))
                return 1;
            else
                return 0;

        
        }
        public int kiemtra_cmnd(String cmnd)
        {
            Regex regex = new Regex(@"[0-9]+");
            if (regex.IsMatch(cmnd) == true && cmnd.Length == 9)
                return 1;
            else
                return 0;


        }
        public int kiemtra_hocky(int hocki)
        {
            if (hocki == 1 | hocki == 2)
                return 1;
            else
            return 0;
        }
        public int kiemtra_conso(int diem)//kiem tra diem
        {
            if (diem >=0 || diem<=10)
                return 1;
            else return 0;

        }

        public void kiemtradb_nguoi(int magv)
        { }
        public int kiemtradb_masv(string massv)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Sinhvien svchk = (from Sinhvien p in ketnoicsdl.db
                                  where p.Ma == massv
                                  select p).SingleOrDefault();
                if (svchk == null)
                    return 0;
                else
                    return 1;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
        public int kiemtradb_magv(string magv)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Giaovien gvchk = (from Giaovien p in ketnoicsdl.db
                                  where p.Ma == magv
                                  select p).SingleOrDefault();
                if (gvchk == null)
                    return 0;
                else
                    return 1;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
        public int kiemtradb_mamh(string mamh)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Monhoc mhchk = (from Monhoc p in ketnoicsdl.db
                                  where p.Mamh == mamh
                                  select p).SingleOrDefault();
                if (mhchk == null)
                    return 0;
                else
                    return 1;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
        public int kiemtradb_malop(string malop)
        {
           try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Lop lopchk = (from Lop p in ketnoicsdl.db
                                where p.Malop == malop
                                select p).SingleOrDefault();
                if (lopchk == null)
                    return 0;
                else
                    return 1;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }
    
        }
        public int kiemtradb_malop_khoa(string malop,string khoa)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Lop lopchk = (from Lop p in ketnoicsdl.db
                              where p.Malop == malop &&p.Makhoa==khoa
                              select p).SingleOrDefault();
                if (lopchk == null)
                    return 0;
                else
                    return 1;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
        public int kiemtradb_manghanh(string manghanh)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Chuyennghanh nghanhchk = (from Chuyennghanh p in ketnoicsdl.db
                                        where p.Manghanh == manghanh
                                select p).SingleOrDefault();
                if (nghanhchk == null)
                    return 0;
                else
                    return 1;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }

        }
        public int kiemtradb_manghanh_khoa(string manghanh,string makhoa)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Chuyennghanh nghanhchk = (from Chuyennghanh p in ketnoicsdl.db
                                          where p.Manghanh == manghanh && p.Makhoa==makhoa
                                          select p).SingleOrDefault();
                if (nghanhchk == null)
                    return 0;
                else
                    return 1;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }

        }
        public int kiemtradb_makhoa(string makhoa)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Khoa khoachk = (from Khoa p in ketnoicsdl.db
                                where p.Makhoa == makhoa
                              select p).SingleOrDefault();
                if (khoachk == null)
                    return 0;
                else
                    return 1;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        
        }
        public int kiemtra_sinhvien(int cmdd)
        {

            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                List<Sinhvien> svexist = (from Sinhvien p in ketnoicsdl.db
                                where p.Cmnd == cmdd
                                select p).ToList();
                if (svexist == null || svexist.Count==0)
                    return 1;
                else
                    return 0;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
        public int kiemtra_sinhvien_up(int cmdd,string masv)
        {

            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                List<Sinhvien> svexist = (from Sinhvien p in ketnoicsdl.db
                                          where p.Cmnd == cmdd 
                                          select p).ToList();
                if (svexist == null || svexist.Count == 0)
                    return 1;
                else if (svexist[0].Ma == masv)
                    return 1;
                else
                    return 0;

            }
            finally
            {
                ketnoicsdl.db.Close();
            }
        }
        public void kiemtratufile_excel(ref string loi,string Ma, string Hoten, string Ngaysinh, string Gioitinh, string Diachi, string Dienthoai, string Malop, string Bacdaotao, string Khoahoc, string Khoa,string Cmnd)
        {
           
            if (kiemtradb_makhoa(Khoa) == 0 && Khoa.Trim()!="")
                loi +="\n" + " Thông tin sinh viên " + Hoten + " không đúng ở các phần sau " + "\n"+ " mã khoa " + Khoa + " không đúng " + "\n";
            if(kiemtradb_malop(Malop)==0 && Malop.Trim()!="")
                loi += Malop+ " mã lớp này không đúng hoặc không có " + "\n";
            if (kiemtradb_malop_khoa(Malop, Khoa) == 0 && Malop.Trim() != "" && Khoa.Trim() != "")
                loi += " mã lớp " + Malop + " này không có trong khoa " + Khoa + "\n";
            if (kiemtra_dienthoai(Dienthoai) == 0 && Dienthoai.Trim() != "")
                loi += " số điện thoại phải là số và có từ 9 đến 11 số " + "\n";
            if (kiemtrangay(Ngaysinh) == 0 && Ngaysinh.Trim()!="")
                loi += " Ngày sinh không đúng định dạng, định dạng đúng ngay/thang/nam " + "\n";
            if (kiemtra_cmnd(Cmnd) == 0 && Cmnd.Trim()!="")
                loi += " Cmnd không đúng định dạng,hoặc có chứa chữ số hoặc không đủ ký tự số theo quy định (9) " + "\n";
           
          
        }
    }
}
