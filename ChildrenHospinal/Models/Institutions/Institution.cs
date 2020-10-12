using ChildrenHospinal.Models.Patients;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Institutions
{
    public class Institution
    {
        public int InstitutionId { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым. Пожалуйста, введите полное ФИО")]
        [Display(Name = "Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым. Пожалуйста, введите адрес")]
        [RegularExpression(@"[a-zA-Z_][a-zA-Z0-9_]*")]
        [Display(Name = "Адрес")]
        [StringLength(150)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым. Пожалуйста, введите телефон")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым. Пожалуйста, введите полное ФИО")]
        [Display(Name = "Директор")]
        [StringLength(100)]
        public string Director { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
