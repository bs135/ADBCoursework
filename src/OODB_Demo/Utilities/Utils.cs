using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODBDemo.Utilities
{
    public static class Utils
    {
        public static int toInt(this string str)
        {
            int i = 0;
            if (int.TryParse(str, out i))
            {
                return i;
            }

            return int.MinValue;
        }


        public static DateTime toDate(this string str)
        {
            DateTime i;
            if (DateTime.TryParse(str, out i))
            {
                return i;
            }

            return new DateTime(0, 0, 0);
        }
    }
}
