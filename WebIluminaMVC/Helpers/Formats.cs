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

    }
}