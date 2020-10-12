using System;
using System.Collections.Generic;
using System.Linq;
using ChildrenHospinal.Models.Diseases;

namespace ChildrenHospinal.Models.Vaccinations
{
    public class DiseaseVaccination
    {
        public Disease Disease { get; set; }
        public VaccinationPlan Vaccination { get; set; }
    }
}
