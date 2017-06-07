using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIluminaMVC.Model
{
    public class SurveyDetail
    {
        [Key]
        public int surveyDetailID { get; set; }
        public int surveyID { get; set; }
        [Display(Name = "Nombres")]
        [MaxLength(length: 500)]
        public string name { get; set; }
        public int type { get; set; }
        public bool active { get; set; }
        [Display(Name = "F. Creación")]
        public DateTime? createDate { get; set; }
        public int? createUser { get; set; }
        [Display(Name = "F. Modificación")]
        public DateTime? updateDate { get; set; }
        public int? updateUser { get; set; }
        public virtual Survey survey { get; set; }
    }
}
