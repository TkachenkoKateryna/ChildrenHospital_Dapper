using ChildrenHospinal.Models.Patients;
using ChildrenHospinal.Models.Specialities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChildrenHospinal.Models.Doctors
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым. Пожалуйста, введите полное ФИО")]
        [RegularExpression(@"^[А-Яа-я\s]+$", ErrorMessage = "ФИО пациента может состоять только из букв")]
        [Display(Name = "Имя")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Номер телефона")]
        [Phone]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^[А-Яа-я\s]+$", ErrorMessage = "Название звания может состоять только из букв")]
        public string Degree { get; set; }

        public string srt { get; set; } 
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Speciality> Speciality { get; set; }
    }
}
