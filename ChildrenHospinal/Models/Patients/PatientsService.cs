using ChildrenHospinal.Models.Vaccinations;
using ChildrenHospinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Patients
{
    public class PatientsService : IPatientsService
    {
        private readonly IPatientRepository repo;
        private readonly IVaccinationRepository repoVac;
        public PatientsService(IPatientRepository r, IVaccinationRepository R)
        {
            repo = r;
            repoVac = R;
        }

        public IEnumerable<PersonalVaccinationPlan> Plan(int id)
        {
            var result = new List<PersonalVaccinationPlan>();
            var patient = repo.GetPatient(id);
            var patientDOB = patient.DOB;
            var allVaccinations = repoVac.GetVaccinationPlan();

            foreach (var vac in allVaccinations)
            {
                var vacDate = new PersonalVaccinationPlan();

                vacDate.Name = vac.Name;

                vacDate.Date = patientDOB.AddMilliseconds(vac.Age).Date;

                result.Add(vacDate);
            }

            return result;
        }

        public IEnumerable<Patient> Notification()
        {
            List<Patient> result = new List<Patient>();
            var patients = repo.GetUnnotifiedPatient();
            var allVaccinations = repoVac.GetVaccinationPlan();
            var currentTime = Convert.ToInt64(DateTime.Now.Date.ToUniversalTime().Subtract(
                                              new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                                              .TotalMilliseconds);
            
            foreach (var vac in allVaccinations)
            {
                foreach (var pat in patients)
                {
                    var d = Convert.ToInt64(pat.DOB.ToUniversalTime().Subtract(
                                            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                                            .TotalMilliseconds);
                    if (d + vac.Age  >= currentTime && d + vac.Age + 86400000 == currentTime + 86400000)
                    {
                        result.Add(pat);
                    }
                }
            }
            return result;
        }

        public long toSeconds(DateTime date)
        {
            return Convert.ToInt64(date.ToUniversalTime().Subtract(
                                   new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                                   .TotalMilliseconds);
        }
    }
}
