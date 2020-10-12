using ChildrenHospinal.Models.Patients;
using ChildrenHospinal.Models.Vaccinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.ViewModels
{
    public class PersonalPlanViewMode
    {
        public IEnumerable<PersonalVaccinationPlan> Plan { get; set; }
        public Patient Patient { get; set; }
    }
}
