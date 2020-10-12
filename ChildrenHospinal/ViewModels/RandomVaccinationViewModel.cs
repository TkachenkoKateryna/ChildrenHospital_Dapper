using ChildrenHospinal.Models.Vaccinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.ViewModels
{
    public class RandomVaccinationViewModel
    {
        public IEnumerable<VaccinationViewModel> Vaccinations { get; set; }
        public VaccinationFilter Filter { get; set; }
    }
}
