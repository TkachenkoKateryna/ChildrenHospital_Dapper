using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Vaccinations
{
    public class VaccinationList
    {
        public string FullName { get; set; }
        public string  Address { get; set; }
        public DateTime DOB { get; set; }
        public string DoctorName { get; set; }
        public string VaccinationName { get; set; }
        public DateTime ProcedureDate { get; set; }
        public bool ProcedureStatus { get; set; }
    }
}
