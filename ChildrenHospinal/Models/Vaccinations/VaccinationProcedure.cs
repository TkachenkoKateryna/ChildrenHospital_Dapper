using ChildrenHospinal.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Vaccinations
{
    public class VaccinationProcedure
    {
        public int VaccinationProcedureId { get; set; }
        public Patient Patient { get; set; }
        public VaccinationPlan Vaccination { get; set; }
        public DateTime Date { get; set; }
        public bool Done { get; set; }
        public string Information { get; set; }
        public bool Notified { get; set; }
    }
}
