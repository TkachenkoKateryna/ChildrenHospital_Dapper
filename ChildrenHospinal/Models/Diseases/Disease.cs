using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Diseases
{
    public class Disease
    {
        public int DiseaseId { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [RegularExpression(@"^[А-Яа-я]+$", ErrorMessage =  "Название болезни может состоять только из букв")]
        [Display(Name = "Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter code")]
        [Display(Name = "Code")]
        [StringLength(10)]
        public string Code { get; set; }

        public string Information { get; set; }
        public bool Infectivity { get; set; }
    }
}
