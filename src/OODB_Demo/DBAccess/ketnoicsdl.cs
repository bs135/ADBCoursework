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
using Db4objects.Db4o.Config;
using Db4objects.Db4o.CS.Config;
using OfficeOpenXml;
using System.IO;
namespace courcework
{
    class ketnoicsdl
    {
     public  static IObjectContainer db;
        public static IObjectContainer Opendb(string dl)
        {
            //thuc hien idex cac cot o day
           // Db4oFactory.Configure().ObjectClass(typeof(NguoiI)).ObjectField("Ma").Indexed(true);
            //Db4oFactory.Configure().ObjectClass(typeof(Sinhvien)).ObjectField("cmnd").Indexed(true);  
             db = Db4oEmbedded.OpenFile(dl);
            return db;
        }
        public static string taomatudong(string tendoituong)
        {
             try
            {
            Opendb("C:\\oodb.db4o");
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
                    if (sv==null)
                    {
                        t = DateTime.Now.Year.ToString() + "00000001";
                    }
                    else
                    {
                        string thu = sv.Ma.Substring(4,8);
                        t = sv.Ma.Substring(0, 4) + themsokhong(Int32.Parse(sv.Ma.Substring(4, 8)) + 1);
                    }
                   
                    break;
                case "lophoc":
                    Lop lop = (from Lop p in ketnoicsdl.db
                                   orderby p.Malop descending
                                   select p).FirstOrDefault();
                    if (lop==null)
                    {
                        t ="LH"+DateTime.Now.Year.ToString() + "000001";
                    }
                    else
                    {

                        t =lop.Malop.Substring(1,6)+ Int32.Parse(lop.Malop.Substring(4, 6))+1;
                    }
                   
                    break;
                   
                case "monhoc"://xem lai giao dien mon hoc roi lam
                    Monhoc mh = (from Monhoc p in ketnoicsdl.db
                                   orderby p.Mamh descending
                                   select p).FirstOrDefault();
                    if (mh==null)
                    {
                        t = "MH"+" "  + "000001";
                    }
                    else
                    {
                        t =mh.Mamh.Substring(1,6)+ Int32.Parse(mh.Mamh.Substring(4, 6))+1;
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
             finally { ketnoicsdl.db.Close(); }
        }
        public static string  themsokhong(int sokt)
        {
            string so = "";
            switch (sokt.ToString().Length)
            {
                case 1:
                    so = "0000000" + sokt;break;
                case 2:
                    so = "000000" + sokt;break;
                case 3:
                    so = "00000" + sokt;break;
                case 4:
                    so = "0000" + sokt;break;
                case 5:
                    so = "000" + sokt;break;
                case 6:
                    so = "00" + sokt; break;
                case 7:
                    so = "0" + sokt;break;
            }
            return so;
        }
        public static List<Khoa>  laydsmonhoc_khoa()
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
        public static void taoexcelfilesv(DataGridView data,int sodong )
        {
            FileInfo newFile = new FileInfo(@"C:\Sinhvien.xlsx");
            // FileInfo newFile_template = new FileInfo(@"C:\template\mauimportsv.xlsx");
            ExcelPackage xlPackage = new ExcelPackage(newFile);//         
            try
            {
                
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
                worksheet.Cell(1, 11).Value = "Cmnd";
                
                    for (int j = 0; j < sodong;j++ )
                        for (int i = 0; i < 11; i++)
                        worksheet.Cell(j+2, i+1).Value = data.Rows[j].Cells[i].Value.ToString();
                   
                xlPackage.Save();
            }
            catch
            {
                MessageBox.Show("bạn đã tao file Sinhvien.xlsx trong ổ C:/ rồi ,muốn tạo lại bạn hãy xóa nó và thực hiện lại");
            }
            
            finally{
                xlPackage.Dispose();
            }
        }
    }

}
