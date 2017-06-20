using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIluminaMVC.Helpers
{
    public class Formats
    {
        public static string DateFormat(DateTime? date)
        {
            return Convert.ToDateTime(date).ToString("dd/MM/yyyy");
        }

        public static string DateFormatShort(DateTime date)
        {
            if (date == DateTime.MinValue)
                return DateTime.Now.ToString("dd/MM/yyyy");
            else
                return date.ToString("dd/MM/yyyy");
        }

    }
}