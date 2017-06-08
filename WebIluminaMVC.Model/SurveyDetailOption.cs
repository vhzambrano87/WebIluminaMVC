﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebIluminaMVC.Model
{
    public class SurveyDetailOption
    {
        [Key]
        public int surveyDetailOptionID { get; set; }
        public int surveyDetailID { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(length: 500)]
        public string name { get; set; }
        public bool active { get; set; }
        [Display(Name = "F. Creación")]
        public DateTime? createDate { get; set; }
        public int? createUser { get; set; }
        [Display(Name = "F. Modificación")]
        public DateTime? updateDate { get; set; }
        public int? updateUser { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool selected { get; set; }
        public virtual SurveyDetail surveyDetail { get; set; }


    }
}