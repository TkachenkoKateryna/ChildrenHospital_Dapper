using ChildrenHospinal.Models.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Specialities
{
    public class Speciality
    {
        public int SpecialityId { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Information { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public Speciality()
        {
            Doctors = new List<Doctor>();
        }
    }
}
