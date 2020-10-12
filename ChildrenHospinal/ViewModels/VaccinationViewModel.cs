using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.ViewModels
{
    public class VaccinationViewModel
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Done { get; set; }
    }
}
