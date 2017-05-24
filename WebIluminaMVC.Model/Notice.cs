using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebIluminaMVC.Model
{
    public class Notice
    {
        [Key]
        public int noticeID { get; set; }
        [Display(Name = "Título")]
        [MaxLength(length: 250)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string title { get; set; }
        [Display(Name = "Fec. Publicación")]
        public DateTime? publishDate { get; set; }
        [Display(Name = "Autor")]
        [MaxLength(length: 250)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string author { get; set; }
        [Display(Name = "Contenido")]
        [MaxLength(length: 750)]
        [Required(ErrorMessage = "Por favor ingresar {0}")]
        public string contents { get; set; }
        [Display(Name = "Imagen URL")]
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
