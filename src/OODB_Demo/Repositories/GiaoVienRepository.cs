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
    public class GiaoVienRepository
    {
        DBConnect dbConnect = new DBConnect();


        public string getNewID()
        {
            Giaovien obj = null;
            string newID = "GV0001";
            try
            {
                dbConnect.Open();
                obj = (from Giaovien p in dbConnect.db
                             orderby p.Ma descending
                             select p).FirstOrDefault();
                dbConnect.Close();

                int i = 0;
                if (obj != null && int.TryParse(obj.Ma.Substring(2), out i))
                {
                    newID = "GV" + (i + 1).ToString("D4");
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
        public Giaovien getById(string ma)
        {
            Giaovien obj = null;
            try
            {
                dbConnect.Open();
                obj = (from Giaovien o in dbConnect.db
                       where o.Ma == ma
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

        public Giaovien getByCmnd(string cmnd)
        {
            Giaovien obj = null;
            try
            {
                dbConnect.Open();
                obj = (from Giaovien o in dbConnect.db
                       where o.Cmnd == cmnd
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
        public IEnumerable<Giaovien> getAll()
        {
            IEnumerable<Giaovien> list = new List<Giaovien>();
            try
            {
                dbConnect.Open();
                list = (from Giaovien o in dbConnect.db
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

            dt.Columns.Add("Ma");
            dt.Columns.Add("Hoten");
            dt.Columns.Add("Ngaysinh");
            dt.Columns.Add("Gioitinh");
            dt.Columns.Add("Diachi");
            dt.Columns.Add("Dienthoai");

            dt.Columns.Add("Email");
            dt.Columns.Add("Makhoa");
            dt.Columns.Add("Trinhdo");
            dt.Columns.Add("Cmnd");
            dt.Columns.Add("Quoctich");
            dt.Columns.Add("Nangkhieu");

            IEnumerable<Giaovien> list = this.getAll();

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim().ToLower();
                list = list.Where(t => t.Ma.ToLower().Contains(keyword) 
                    || t.Hoten.ToLower().Contains(keyword)
                    || t.Diachi.ToLower().Contains(keyword)
                    || t.Dienthoai.ToLower().Contains(keyword)
                    || t.Email.ToLower().Contains(keyword)
                    || t.Makhoa.ToLower().Contains(keyword)
                    || t.Trinhdo.ToLower().Contains(keyword)
                    || t.Cmnd.ToLower().Contains(keyword)
                    || t.Quoctich.ToLower().Contains(keyword)
                    || t.Nangkhieu.ToLower().Contains(keyword));
            }

            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["Ma"] = item.Ma;
                row["Hoten"] = item.Hoten;
                row["Ngaysinh"] = item.Ngaysinh;
                row["Gioitinh"] = item.Gioitinh;
                row["Diachi"] = item.Diachi;
                row["Dienthoai"] = item.Dienthoai;

                row["Email"] = item.Email;
                row["Makhoa"] = item.Makhoa;
                row["Trinhdo"] = item.Trinhdo;
                row["Cmnd"] = item.Cmnd;
                row["Quoctich"] = item.Quoctich;
                row["Nangkhieu"] = item.Nangkhieu;


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
        public void add(string ma, string hoten, string ngaysinh, string gioitinh, string diachi, string dienthoai, string email, string makhoa, string trinhdo, string cmnd, string quoctich, string nangkhieu)
        {
            Giaovien obj = new Giaovien();
            obj.Ma = ma;
            obj.Hoten = hoten;
            obj.Ngaysinh = ngaysinh;
            obj.Gioitinh = gioitinh;
            obj.Diachi = diachi;
            obj.Dienthoai = dienthoai;

            obj.Email = email;
            obj.Makhoa = makhoa;
            obj.Trinhdo = trinhdo;
            obj.Cmnd = cmnd;
            obj.Quoctich = quoctich;
            obj.Nangkhieu = nangkhieu;

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
                Giaovien obj = (from Giaovien o in dbConnect.db
                              where o.Ma == ma
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
        public void update(string ma, string hoten, string ngaysinh, string gioitinh, string diachi, string dienthoai, string email, string makhoa, string trinhdo, string cmnd, string quoctich, string nangkhieu)
        {
            try
            {
                dbConnect.Open();
                Giaovien obj = (from Giaovien o in dbConnect.db
                              where o.Ma == ma
                              select o).FirstOrDefault();
                if (obj != null)
                {
                    obj.Hoten = hoten;
                    obj.Ngaysinh = ngaysinh;
                    obj.Gioitinh = gioitinh;
                    obj.Diachi = diachi;
                    obj.Dienthoai = dienthoai;

                    obj.Email = email;
                    obj.Makhoa = makhoa;
                    obj.Trinhdo = trinhdo;
                    obj.Cmnd = cmnd;
                    obj.Quoctich = quoctich;
                    obj.Nangkhieu = nangkhieu;

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
                var excelSheet = from item in excelFile.Worksheet<Giaovien>(sheetName) select item;
                foreach (var item in excelSheet)
                {
                    if (!this.isExist(item.Ma))
                    {
                        if (this.isValid(item.Hoten, item.Ngaysinh, item.Gioitinh, item.Diachi, item.Dienthoai, item.Email, item.Makhoa, item.Trinhdo, item.Cmnd, item.Quoctich, item.Nangkhieu))
                        {
                            this.add(item.Ma, item.Hoten, item.Ngaysinh, item.Gioitinh, item.Diachi, item.Dienthoai, item.Email, item.Makhoa, item.Trinhdo, item.Cmnd, item.Quoctich, item.Nangkhieu);
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
                worksheet.Cell(1, 1).Value = "Mã";
                worksheet.Cell(1, 2).Value = "Họ tên";
                worksheet.Cell(1, 3).Value = "Ngày sinh";
                worksheet.Cell(1, 4).Value = "Giới tính";
                worksheet.Cell(1, 5).Value = "Địa chỉ";
                worksheet.Cell(1, 6).Value = "Điện thoại";
                worksheet.Cell(1, 7).Value = "Email";
                worksheet.Cell(1, 8).Value = "Mã khoa";
                worksheet.Cell(1, 9).Value = "Trình độ";
                worksheet.Cell(1, 10).Value = "Phân loại";
                worksheet.Cell(1, 11).Value = "Quốc tịch";
                worksheet.Cell(1, 12).Value = "Năng khiếu";
                //MessageBox.Show(data.Rows[6].Cells[2].Value.ToString());
                //return false;
                int rowCount = data.Rows.Count;
                for (int r = 0; r < rowCount; r++)
                    for (int c = 0; c < 12; c++)
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
        public bool isValid(string hoten, string ngaysinh, string gioitinh, string diachi, string dienthoai, string email, string makhoa, string trinhdo, string cmnd, string quoctich, string nangkhieu)
        {
            if (string.IsNullOrEmpty(hoten)) return false;
            if (string.IsNullOrEmpty(ngaysinh)) return false; if (!ngaysinh.isDate()) return false;
            if (string.IsNullOrEmpty(gioitinh)) return false;
            if (string.IsNullOrEmpty(diachi)) return false;
            if (!dienthoai.isPhoneNumber()) return false;
            if (!email.isEmailAddress()) return false;
            if (string.IsNullOrEmpty(makhoa)) return false;
            if (string.IsNullOrEmpty(trinhdo)) return false;
            if (string.IsNullOrEmpty(cmnd)) return false;
            if (string.IsNullOrEmpty(quoctich)) return false;
            if (string.IsNullOrEmpty(nangkhieu)) return false;
            return true;
        }

        /// <summary>
        /// Kiểm tra mã môn học có trong csdl chưa
        /// </summary>
        /// <param name="mamh"></param>
        /// <returns></returns>
        public bool isExist(string cmnd)
        {
            Giaovien obj = this.getByCmnd(cmnd);
            if (obj == null) return false;
            return true;
        }
    }
}
