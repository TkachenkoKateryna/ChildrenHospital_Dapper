using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Institutions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Patients
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым. Пожалуйста, введите полное ФИО")]
        [Display(Name = "Имя")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым. Пожалуйста, введите дату рождения")]
        [RegularExpression(@"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))", ErrorMessage = "Введите дату в формате yyyy-mm-dd")]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Поле не может быть пустым. Пожалуйста, введите адрес")]
        [RegularExpression(@"[a-zA-Z_][a-zA-Z0-9_]*")]
        [Display(Name = "Адрес")]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        public Institution Institution { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        [Required]
        public string Email { get; set; }
        bool Notified { get; set; }
    }
}
