using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace OODBDemo.Utilities
{
    public static class Utils
    {
        public static int toInteger(this string str)
        {
            try
            {
                int i = 0;
                if (int.TryParse(str, out i))
                {
                    return i;
                }

            }
            catch { }
            return int.MinValue;
        }


        public static DateTime toDate(this string str)
        {
            try
            {
                DateTime date;
                if (DateTime.TryParse(str, out date))
                {
                    return date;
                }
            }
            catch { }
            return new DateTime(1, 1, 1);
        }


        public static bool isPhoneNumber(this string phonenum)
        {
            try
            {
                if (string.IsNullOrEmpty(phonenum))
                    return false;
                var r = new Regex(@"^[+]?[0-9]{9,11}$");
                return r.IsMatch(phonenum);

            }
            catch
            {
                return false;
            }
        }

        public static bool isEmailAddress(this string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch //(FormatException)
            {
                return false;
            }
        }

        public static bool isDate(this string date)
        {
            try
            {
                DateTime Test;
                if (DateTime.TryParse(date, out Test))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool isCMNDNumber(this string num)
        {
            try
            {
                if (string.IsNullOrEmpty(num))
                    return false;
                var r = new Regex(@"^[0-9]{9}$");
                return r.IsMatch(num);

            }
            catch
            {
                return false;
            }
        }
    }
}
