using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Patients
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(int id);
        IEnumerable<Patient> GetUnnotifiedPatient();
    }
}
