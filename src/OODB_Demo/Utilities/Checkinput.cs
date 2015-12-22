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
using OfficeOpenXml;
using System.IO;
using System.Text.RegularExpressions;
namespace OODBDemo
{
    class Checkinput
    {
        public void taoexcelfilesv()
        {
            FileInfo newFile = new FileInfo(@"C:\Sinhvien.xlsx");
            // FileInfo newFile_template = new FileInfo(@"C:\template\mauimportsv.xlsx");
            try
            {
                ExcelPackage xlPackage = new ExcelPackage(newFile);//         
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cell(1, 1).Value = "Ma";
                worksheet.Cell(1, 2).Value = "Hoten";
                worksheet.Cell(1, 3).Value = "Ngaysinh";
                worksheet.Cell(1, 4).Value = "Gioitinh";
                worksheet.Cell(1, 5).Value = "Diachi";
                worksheet.Cell(1, 6).Value = "Dienthoai";
                worksheet.Cell(1, 7).Value = "Malop";
                worksheet.Cell(1, 8).Value = "Bacdaotao";
                worksheet.Cell(1, 9).Value = "Khoahoc";
                worksheet.Cell(1, 10).Value = "Khoa";
                worksheet.Cell(1, 11).Value = "Nganhhoc";
                xlPackage.Save();
            }
            catch
            {
                MessageBox.Show("bạn đã tao file Sinhvien.xlsx nay trong ổ C:/ rồi ,muốn tạo lại bạn hãy xóa nó và thực hiện lại");
            }
        }



        public string kiemtranull(object c)
        {
            if (c == null)
                return "gia tri null";
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
        public int kiemtra_hocky(int hocki)
        {
            if (hocki == 1 | hocki == 2)
                return 1;
            else
                return 0;
        }
        public int kiemtra_conso(int diem)//kiem tra diem
        {
            if (diem >= 0 || diem <= 10)
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
        public int kiemtradb_malop_khoa(string malop, string khoa)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Lop lopchk = (from Lop p in ketnoicsdl.db
                              where p.Malop == malop && p.Makhoa == khoa
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
        public int kiemtradb_manghanh_khoa(string manghanh, string makhoa)
        {
            try
            {
                ketnoicsdl.Opendb("C:\\oodb.db4o");
                Chuyennghanh nghanhchk = (from Chuyennghanh p in ketnoicsdl.db
                                          where p.Manghanh == manghanh && p.Makhoa == makhoa
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
        public void kiemtratufile_excel(ref string loi, string Ma, string Hoten, string Ngaysinh, string Gioitinh, string Diachi, string Dienthoai, string Malop, string Bacdaotao, string Khoahoc, string Khoa, string Nganhhoc)
        {
            loi += "\n" + " Mã sinh viên này " + Ma + " không đúng ở các phần sau " + "\n";
            if (kiemtradb_makhoa(Khoa) == 0)
                loi += " mã khoa " + Khoa + " không đúng" + "\n";
            if (kiemtradb_manghanh(Nganhhoc) == 0)
                loi += " mã nghành " + Nganhhoc + " không đúng " + "\n";
            if (kiemtradb_manghanh_khoa(Nganhhoc, Khoa) == 0)
                loi += " mã nghành " + Nganhhoc + " này không thuộc khoa " + Khoa + "\n";
            if (kiemtradb_malop(Malop) == 0)
                loi += Malop + " mã lớp này không đúng" + "\n";
            if (kiemtradb_malop_khoa(Malop, Khoa) == 0)
                loi += " mã lớp " + Malop + " này không có trong khoa " + Khoa + "\n";
            if (kiemtra_dienthoai(Dienthoai) == 0)
                loi += " số điện thoại phải là số và có từ 9 đến 11 số " + "\n";
            if (kiemtrangay(Ngaysinh) == 0)
                loi += " Ngày sinh không đúng định dạng, định dạng đúng ngay/thang/nam" + "\n";


        }
    }
}
