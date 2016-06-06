using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using LinqToExcel;
using System.Data;
using System.IO;
using OfficeOpenXml;
using OODBDemo.DBAccess;
using OODBDemo.Entities;

namespace OODBDemo.Repositories
{
    public class DiemRepository
    {
        DBConnect dbConnect = new DBConnect();



        /// <summary>
        /// lấy môn học theo mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public Diemsv getById(string ma, string mssv)
        {
            Diemsv obj = null;
            try
            {
                dbConnect.Open();
                obj = (from Diemsv o in dbConnect.db
                       where (o.Mamh == ma) && (o.Masv == mssv)
                       select o).FirstOrDefault();
                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }

            return obj;
        }


        /// <summary>
        /// lấy danh sách môn học
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Diemsv> getAll()
        {
            IEnumerable<Diemsv> list = new List<Diemsv>();
            try
            {
                dbConnect.Open();
                list = (from Diemsv o in dbConnect.db
                        select o).ToList();
                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }

            return list;

        }


        /// <summary>
        /// lấy danh sách môn học theo dạng bảng
        /// </summary>
        /// <returns></returns>
        public DataTable getTable(string keyword = "")
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Masv");
            dt.Columns.Add("Mamh");
            dt.Columns.Add("Diem");
            dt.Columns.Add("Lanthu");
            dt.Columns.Add("Ghichu");
            dt.Columns.Add("Hocki");

            IEnumerable<Diemsv> list = this.getAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim().ToLower();
                list = list.Where(t => t.Masv.ToLower().Contains(keyword)
                    || t.Mamh.ToLower().Contains(keyword)
                    || t.Diem.ToString().Contains(keyword)
                    || t.Lanthu.ToString().Contains(keyword)
                    || t.Ghichu.ToLower().Contains(keyword)
                    || t.Hocki.ToString().Contains(keyword));
            }

            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["Masv"] = item.Masv;
                row["Mamh"] = item.Mamh;
                row["Diem"] = item.Diem;
                row["Lanthu"] = item.Lanthu;
                row["Ghichu"] = item.Ghichu;
                row["Hocki"] = item.Hocki;

                dt.Rows.Add(row);
            }

            return dt;
        }


        /// <summary>
        /// thêm môn học
        /// </summary>
        /// <param name="mamh"></param>
        /// <param name="tenmh"></param>
        /// <param name="sochi"></param>
        public void add(string masv, string mamh, double diem, int lanthu, string ghichu, string hocki)
        {
            Diemsv obj = new Diemsv();
            obj.Masv = masv;
            obj.Mamh = mamh;
            obj.Diem = diem;
            obj.Lanthu = lanthu;
            obj.Ghichu = ghichu;
            obj.Hocki = hocki;

            try
            {
                dbConnect.Open();
                dbConnect.db.Store(obj);
                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }
        }

        /// <summary>
        /// xóa môn học
        /// </summary>
        /// <param name="ma"></param>
        public void delete(string mamh, string mssv)
        {
            try
            {
                dbConnect.Open();
                Diemsv obj = (from Diemsv o in dbConnect.db
                              where (o.Mamh == mamh) && (o.Masv == mssv)
                              select o).FirstOrDefault();
                if (obj != null)
                {
                    dbConnect.db.Delete(obj);
                }

                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }
        }

        /// <summary>
        /// cập nhật môn học
        /// </summary>
        /// <param name="mamh"></param>
        /// <param name="tenmh"></param>
        /// <param name="sochi"></param>
        public void update(string masv, string mamh, double diem, int lanthu, string ghichu, string hocki)
        {
            try
            {
                dbConnect.Open();
                Diemsv obj = (from Diemsv o in dbConnect.db
                              where (o.Mamh == mamh) && (o.Masv == masv)
                              select o).FirstOrDefault();
                if (obj != null)
                {
                    obj.Diem = diem;
                    obj.Lanthu = lanthu;
                    obj.Ghichu = ghichu;
                    obj.Hocki = hocki;
                    dbConnect.db.Store(obj);
                }

                dbConnect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConnect.Close();
            }

        }

        /// <summary>
        /// nhập dữ liệu từ file excel
        /// </summary>
        /// <param name="pathToExcelFile"></param>
        /// <returns></returns>
        public bool importFromExcel(string pathToExcelFile)
        {
            try
            {
                string sheetName = "Sheet1";
                var excelFile = new ExcelQueryFactory(pathToExcelFile);
                var excelSheet = from item in excelFile.Worksheet<Diemsv>(sheetName) select item;
                foreach (var item in excelSheet)
                {
                    if (!this.isExist(item.Mamh, item.Masv))
                    {
                        if (this.isValid(item.Masv, item.Mamh, item.Diem, item.Lanthu, item.Ghichu, item.Hocki))
                        {
                            this.add(item.Masv, item.Mamh, item.Diem, item.Lanthu, item.Ghichu, item.Hocki);
                        }
                    }
                }
                return true;
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }


        public bool exportFromExcel(DataGridView data, string pathToExcelFile)
        {
            if (File.Exists(pathToExcelFile)) File.Delete(pathToExcelFile);

            FileInfo excelFile = new FileInfo(pathToExcelFile);
            ExcelPackage excelPackage = new ExcelPackage(excelFile);
            try
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cell(1, 1).Value = "Mã SV";
                worksheet.Cell(1, 2).Value = "Mã MH";
                worksheet.Cell(1, 3).Value = "Điểm";
                worksheet.Cell(1, 4).Value = "Lần Thứ";
                worksheet.Cell(1, 5).Value = "Ghi chú";
                worksheet.Cell(1, 6).Value = "Học kỳ";

                //MessageBox.Show(data.Rows[6].Cells[2].Value.ToString());
                //return false;
                int rowCount = data.Rows.Count;
                for (int r = 0; r < rowCount; r++)
                    for (int c = 0; c < 6; c++)
                        worksheet.Cell(r + 2, c + 1).Value = data.Rows[r].Cells[c].Value.ToString();

                excelPackage.Save();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                excelPackage.Dispose();
            }
        }

        /// <summary>
        /// kiểm tra thông tin có hợp lệ là một môn học không
        /// </summary>
        /// <param name="mamh"></param>
        /// <param name="tenmh"></param>
        /// <param name="sochi"></param>
        /// <returns></returns>
        public bool isValid(string masv, string mamh, double diem, int lanthu, string ghichu, string hocki)
        {
            if (string.IsNullOrEmpty(mamh)) return false;
            if (string.IsNullOrEmpty(masv)) return false;
            if (diem.Equals("")) return false;
            if (hocki.Equals("")) return false;
            if (lanthu.Equals("")) return false;

            if (diem <= 0) return false;
            return true;
        }

        /// <summary>
        /// Kiểm tra mã môn học có trong csdl chưa
        /// </summary>
        /// <param name="mamh"></param>
        /// <returns></returns>
        public bool isExist(string mamh, string mssv)
        {
            Diemsv obj = this.getById(mamh, mssv);
            if (obj == null) return false;
            return true;
        }
    }
}
