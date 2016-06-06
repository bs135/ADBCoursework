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
namespace OODBDemo
{
    public class Sinhvien : NguoiI
    {
        public string Malop { get; set; }
        public string Bacdaotao { get; set; }
        public int Khoahoc { get; set; }
        public string Khoa { get; set; }

    }

}
