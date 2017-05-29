using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIluminaMVC.Model
{
    public class Event
    {
        [Key]
        public int eventID { get; set; }
        [Display(Name = "Título")]
        [MaxLength(length: 250)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string title { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? date { get; set; }
        [Display(Name = "Lugar")]
        [MaxLength(length: 250)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string place { get; set; }
        [Display(Name = "Imagen")]
        [MaxLength(length: 100)]
        public string imageUrl { get; set; }
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
