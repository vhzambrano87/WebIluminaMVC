using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIluminaMVC.Model
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }
        [Display(Name = "Nombres")]
        [MaxLength(length: 100)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]

        public string name { get; set; }
        [Display(Name = "Apellido Paterno")]
        [MaxLength(length: 100)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string lastname_first { get; set; }

        [Display(Name = "Apellido Materno")]
        [MaxLength(length: 100)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string lastname_second { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(length: 20)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string mobilephone { get; set; }

        [Display(Name = "Área")]
        [MaxLength(length: 100)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string area { get; set; }

        [Display(Name = "Email")]
        [MaxLength(length: 100)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string email { get; set; }
        
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
