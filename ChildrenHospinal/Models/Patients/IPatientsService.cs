using ChildrenHospinal.Models.Vaccinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Patients
{
    public interface IPatientsService
    {
        IEnumerable<PersonalVaccinationPlan> Plan(int id);

        IEnumerable<Patient> Notification();
    }
}
