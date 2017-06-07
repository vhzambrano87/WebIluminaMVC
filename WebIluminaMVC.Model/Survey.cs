using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIluminaMVC.Model
{
    public class Survey
    {
        [Key]
        public int surveyID { get; set; }
        [Display(Name = "Nombres")]
        [MaxLength(length: 250)]
        public string name { get; set; }
        [Display(Name = "Fec. Inicio")]
        public DateTime dateFrom { get; set; }
        [Display(Name = "Fec. Fin")]
        public DateTime dateTo { get; set; }
        [Display(Name = "Activo")]
        public bool active { get; set; }
        [Display(Name = "F. Creación")]
        public DateTime? createDate { get; set; }
        public int? createUser { get; set; }
        [Display(Name = "F. Modificación")]
        public DateTime? updateDate { get; set; }
        public int? updateUser { get; set; }

    }
}
