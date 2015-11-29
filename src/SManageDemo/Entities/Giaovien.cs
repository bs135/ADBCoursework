using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODBCourcework
{
    class Giaovien : Nguoi
    {
        string email;
        string makhoa;
        string trinhdo;
        string phanloai;
        string quoctich;
        string nangkhieu;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Makhoa
        {
            get { return makhoa; }
            set { makhoa = value; }
        }
        public string Trinhdo
        {
            get { return trinhdo; }
            set { trinhdo = value; }
        }
        public string Phanloai
        {
            get { return phanloai; }
            set { phanloai = value; }
        }
        public string Quoctich
        {
            get { return quoctich; }
            set { quoctich = value; }
        }
        public string Nangkhieu
        {
            get { return nangkhieu; }
            set { nangkhieu = value; }
        }
    }

}
