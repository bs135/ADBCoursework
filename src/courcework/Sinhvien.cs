using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
namespace courcework
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
        public void addsv(int ma, string hoten, string ngaysinh, string gioitinh
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
        public int xoasv(string  ma)
        {
            
            return 0;
        }
        public Sinhvien updatesv(int ma, string hoten, string ngaysinh, string gioitinh, string diachi, int dienthoai)
        {
            Sinhvien sv = new Sinhvien();
            sv.Ma = ma;
            sv.Hoten = hoten;
            sv.Ngaysinh = ngaysinh;
            sv.Gioitinh = gioitinh;
            sv.Diachi = diachi;
            sv.Dienthoai = dienthoai;
            return new Sinhvien();
        }
        public void findsv()
        { 
        
        }
    }

}
