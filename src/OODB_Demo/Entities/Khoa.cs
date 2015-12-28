using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using LinqToExcel;
using System.Globalization;
using System.Windows.Forms;

namespace OODBDemo.Entities
{
    public class Khoa
    {
        public string Makhoa { get; set; }
        public string Tenkhoa { get; set; }
        public string Truongkhoa { get; set; }
        public string Photruongkhoa { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
    }
}
