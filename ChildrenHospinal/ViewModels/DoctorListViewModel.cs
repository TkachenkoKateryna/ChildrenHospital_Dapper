using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Specialities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.ViewModels
{
    public class DoctorListViewModel
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public DoctorFilter Filter { get; set; }
        public IEnumerable<Speciality> Specialities { get; set; }
        public IEnumerable<string> Degree { get; set; }
        public string SearchTerm
        {
            get; set;
        }
    }
}
