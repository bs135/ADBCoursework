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
    public class LopRepository
    {
        DBConnect dbConnect = new DBConnect();

        public string getNewID()
        {
            Lop obj = null;
            string newID = "LOP0001";
            try
            {
                dbConnect.Open();
                obj = (from Lop o in dbConnect.db
                       orderby o.Malop descending
                       select o).FirstOrDefault();
                dbConnect.Close();

                int i = 0;
                if (obj != null && int.TryParse(obj.Malop.Substring(3), out i))
                {
                    newID = "LOP" + (i + 1).ToString("D4");
                }
                return newID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return newID;
            }
            finally
            {
                dbConnect.Close();
            }
        }

        /// <summary>
        /// lấy môn học theo mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public Lop getById(string ma)
        {
            Lop obj = null;
            try
            {
                dbConnect.Open();
                obj = (from Lop o in dbConnect.db
                       where o.Malop == ma
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
        public IEnumerable<Lop> getAll()
        {
            IEnumerable<Lop> list = new List<Lop>();
            try
            {
                dbConnect.Open();
                list = (from Lop o in dbConnect.db
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

            dt.Columns.Add("Malop");
            dt.Columns.Add("Tenlop");
            dt.Columns.Add("Makhoa");
            IEnumerable<Lop> list = this.getAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim().ToLower();
                list = list.Where(t => t.Malop.ToLower().Contains(keyword) || t.Tenlop.ToLower().Contains(keyword) || t.Makhoa.ToLower().Contains(keyword));
            }

            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["Malop"] = item.Malop;
                row["Tenlop"] = item.Tenlop;
                row["Makhoa"] = item.Makhoa;

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
        public void add(string malop, string tenlop, string makhoa)
        {
            Lop obj = new Lop();
            obj.Malop = malop;
            obj.Tenlop = tenlop;
            obj.Makhoa = makhoa;
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
        public void delete(string ma)
        {
            try
            {
                dbConnect.Open();
                Lop obj = (from Lop o in dbConnect.db
                              where o.Malop == ma
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
        public void update(string malop, string tenlop, string makhoa)
        {
            try
            {
                dbConnect.Open();
                Lop obj = (from Lop o in dbConnect.db
                              where o.Malop == malop
                              select o).FirstOrDefault();
                if (obj != null)
                {
                    obj.Tenlop = tenlop;
                    obj.Makhoa = makhoa;

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
                var excelSheet = from item in excelFile.Worksheet<Lop>(sheetName) select item;
                foreach (var item in excelSheet)
                {
                    if (!this.isExist(item.Malop))
                    {
                        if (this.isValid(item.Tenlop, item.Makhoa))
                        {
                            this.add(this.getNewID(), item.Tenlop, item.Makhoa);
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
                worksheet.Cell(1, 1).Value = "Mã lớp";
                worksheet.Cell(1, 2).Value = "Tên lớp";
                worksheet.Cell(1, 3).Value = "Khoa";
                //MessageBox.Show(data.Rows[6].Cells[2].Value.ToString());
                //return false;
                int rowCount = data.Rows.Count;
                for (int r = 0; r < rowCount; r++)
                    for (int c = 0; c < 3; c++)
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
        /// <param name="tenmh"></param>
        /// <param name="sochi"></param>
        /// <returns></returns>
        public bool isValid(string tenlop, string makhoa)
        {
            if (string.IsNullOrEmpty(tenlop)) return false;
            if (string.IsNullOrEmpty(makhoa)) return false;
            return true;
        }

        /// <summary>
        /// Kiểm tra mã môn học có trong csdl chưa
        /// </summary>
        /// <param name="mamh"></param>
        /// <returns></returns>
        public bool isExist(string ma)
        {
            Lop obj = this.getById(ma);
            if (obj == null) return false;
            return true;
        }
    }
}
