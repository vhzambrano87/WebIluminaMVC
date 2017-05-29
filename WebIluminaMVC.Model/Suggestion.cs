using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIluminaMVC.Model
{
    public class Suggestion
    {
        [Key]
        public int suggestionID { get; set; }
        public int employeeID { get; set; }
        [Display(Name = "Sugerencia")]
        [MaxLength(length: 500)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string content { get; set; }
        public DateTime? date { get; set; }
        public virtual Employee employee { get; set; }
    }
}
