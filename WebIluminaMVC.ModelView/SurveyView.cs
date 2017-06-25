using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebIluminaMVC.Model;

namespace WebIluminaMVC.ModelView
{
    public class SurveyView
    {
        public Survey survey { get; set; }
        public SurveyDetail surveyDetail { get; set; }
        public IList<SurveyDetail> surveyDetailList { get; set; }
        public string action { get; set; }
    }
}
