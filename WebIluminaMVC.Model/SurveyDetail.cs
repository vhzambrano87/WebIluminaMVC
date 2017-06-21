using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Display(Name = "ID Encuesta")]
        public int surveyID { get; set; }
        [Display(Name = "Preguntas")]
        [MaxLength(length: 500)]
        public string name { get; set; }
        [Display(Name = "Tipo")]
        public string type { get; set; }
        [Display(Name = "Activo")]
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
