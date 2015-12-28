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
using OODBDemo.Utilities;

namespace OODBDemo.Repositories
{
    public class KhoaRepository
    {
        DBConnect dbConnect = new DBConnect();



        /// <summary>
        /// lấy môn học theo mã
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public Khoa getById(string ma)
        {
            Khoa obj = null;
            try
            {
                dbConnect.Open();
                obj = (from Khoa o in dbConnect.db
                       where o.Makhoa == ma
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
        /// tìm khoa theo tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Khoa getByName(string name)
        {
            Khoa obj = null;
            try
            {
                dbConnect.Open();
                obj = (from Khoa o in dbConnect.db
                       where o.Tenkhoa == name
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
        public IEnumerable<Khoa> getAll()
        {
            IEnumerable<Khoa> list = new List<Khoa>();
            try
            {
                dbConnect.Open();
                list = (from Khoa o in dbConnect.db
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

            dt.Columns.Add("Makhoa");
            dt.Columns.Add("Tenkhoa");
            dt.Columns.Add("Truongkhoa");
            dt.Columns.Add("Photruongkhoa");
            dt.Columns.Add("Email");
            dt.Columns.Add("Diachi");
            dt.Columns.Add("Dienthoai");

            IEnumerable<Khoa> list = this.getAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim().ToLower();
                list = list.Where(t => t.Makhoa.ToLower().Contains(keyword) 
                    || t.Tenkhoa.ToLower().Contains(keyword)
                    || t.Truongkhoa.ToLower().Contains(keyword)
                    || t.Photruongkhoa.ToLower().Contains(keyword)
                    || t.Email.ToLower().Contains(keyword)
                    || t.Diachi.ToLower().Contains(keyword)
                    || t.Dienthoai.ToLower().Contains(keyword));
            }

            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["Makhoa"] = item.Makhoa;
                row["Tenkhoa"] = item.Tenkhoa;
                row["Truongkhoa"] = item.Truongkhoa;
                row["Photruongkhoa"] = item.Photruongkhoa;
                row["Email"] = item.Email;
                row["Diachi"] = item.Diachi;
                row["Dienthoai"] = item.Dienthoai;

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
        public void add(string makhoa, string tenkhoa, string truongkhoa, string photruongkhoa, string email, string diachi, string dienthoai)
        {
            Khoa obj = new Khoa();
            obj.Makhoa = makhoa;
            obj.Tenkhoa = tenkhoa;
            obj.Truongkhoa = truongkhoa;
            obj.Photruongkhoa = photruongkhoa;
            obj.Email = email;
            obj.Diachi = diachi;
            obj.Dienthoai = dienthoai;
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
                Khoa obj = (from Khoa o in dbConnect.db
                              where o.Makhoa == ma
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
        public void update(string makhoa, string tenkhoa, string truongkhoa, string photruongkhoa, string email, string diachi, string dienthoai)
        {
            try
            {
                dbConnect.Open();
                Khoa obj = (from Khoa o in dbConnect.db
                              where o.Makhoa == makhoa
                              select o).FirstOrDefault();
                if (obj != null)
                {
                    //obj.Makhoa = makhoa;
                    obj.Tenkhoa = tenkhoa;
                    obj.Truongkhoa = truongkhoa;
                    obj.Photruongkhoa = photruongkhoa;
                    obj.Email = email;
                    obj.Diachi = diachi;
                    obj.Dienthoai = dienthoai;

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
                var excelSheet = from item in excelFile.Worksheet<Khoa>(sheetName) select item;
                foreach (var item in excelSheet)
                {
                    if (!this.isExist(item.Makhoa))
                    {
                        if (this.isValid(item.Makhoa, item.Tenkhoa, item.Truongkhoa, item.Photruongkhoa, item.Email, item.Diachi, item.Dienthoai))
                        {
                            this.add(item.Makhoa, item.Tenkhoa, item.Truongkhoa, item.Photruongkhoa, item.Email, item.Diachi, item.Dienthoai);
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
                worksheet.Cell(1, 1).Value = "Mã Khoa";
                worksheet.Cell(1, 2).Value = "Tên Khoa";
                worksheet.Cell(1, 3).Value = "Trưởng Khoa";
                worksheet.Cell(1, 4).Value = "P. Trưởng Khoa";
                worksheet.Cell(1, 5).Value = "Email";
                worksheet.Cell(1, 6).Value = "Địa chỉ";
                worksheet.Cell(1, 7).Value = "Điện thoại";


                int rowCount = data.Rows.Count;
                for (int r = 0; r < rowCount; r++)
                    for (int c = 0; c < 7; c++)
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
        public bool isValid(string makhoa, string tenkhoa, string truongkhoa, string photruongkhoa, string email, string diachi, string dienthoai)
        {
            if (string.IsNullOrEmpty(makhoa)) return false;
            if (string.IsNullOrEmpty(tenkhoa)) return false;
            if (string.IsNullOrEmpty(truongkhoa)) return false;
            if (string.IsNullOrEmpty(photruongkhoa)) return false;
            if (!email.isEmailAddress()) return false;
            if (string.IsNullOrEmpty(diachi)) return false;
            if (!dienthoai.isPhoneNumber()) return false;
            return true;
        }

        /// <summary>
        /// Kiểm tra mã môn học có trong csdl chưa
        /// </summary>
        /// <param name="mamh"></param>
        /// <returns></returns>
        public bool isExist(string ma)
        {
            Khoa obj = this.getById(ma);
            if (obj == null) return false;
            return true;
        }

        public bool isExistName(string name)
        {
            Khoa obj = this.getByName(name);
            if (obj == null) return false;
            return true;
        }
    }
}
