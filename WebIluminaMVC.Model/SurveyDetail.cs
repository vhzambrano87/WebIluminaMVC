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
        [Display(Name = "Pregunta")]
        [MaxLength(length: 500)]
        public string name { get; set; }
        [Display(Name = "Tipo")]
        public string type { get; set; }
        [Display(Name = "Opción 1")]
        [MaxLength(length: 500)]
        public string option1 { get; set; }
        [Display(Name = "Opción 2")]
        [MaxLength(length: 500)]
        public string option2 { get; set; }
        [Display(Name = "Opción 3")]
        [MaxLength(length: 500)]
        public string option3 { get; set; }
        [Display(Name = "Opción 4")]
        [MaxLength(length: 500)]
        public string option4 { get; set; }
        [Display(Name = "Opción 5")]
        [MaxLength(length: 500)]
        public string option5 { get; set; }
        [Display(Name = "Opción 6")]
        [MaxLength(length: 500)]
        public string option6 { get; set; }
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
