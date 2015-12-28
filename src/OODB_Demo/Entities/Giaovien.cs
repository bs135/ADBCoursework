using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODBDemo.Entities
{
    public class Giaovien : NguoiI
    {
        public string Email { get; set; }
        public string Makhoa { get; set; }
        public string Trinhdo { get; set; }
        public string Quoctich { get; set; }
        public string Nangkhieu { get; set; }
    }
}
