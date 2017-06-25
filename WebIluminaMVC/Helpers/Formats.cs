using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebIluminaMVC.DataAccess;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.Helpers
{
    public class Formats
    {
        private IluminaContext db = new IluminaContext();
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

        public SurveyDetail getSurveyDetail(int? id)
        {
            SurveyDetail objSurveyDetail;

            if (id == 0)
            {
                return objSurveyDetail = new SurveyDetail { option1 = "", option2 = "", option3 = "", option4 = "", option5 = "", option6 = "" };
            }
            return db.SurveyDetail.Find(id);
        }
    }
}