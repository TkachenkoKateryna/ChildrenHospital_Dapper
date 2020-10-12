using ChildrenHospinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Vaccinations
{
    public interface IVaccinationRepository
    {
        IEnumerable<RepeatedVaccinations> GetRepeatedVaccinations();
        IEnumerable<VaccinationViewModel> GetAllVaccinations();
        List<VaccinationPlanObject> GetVaccinationPlan();
        VaccinationProcedure GetProcedure(int a, int b);
        IEnumerable<CrossRequest> CrossRequest();
        List<VaccinationList> GetVaccinationList(int idp);
        void DeleteVaccination(int id);
    }
}
