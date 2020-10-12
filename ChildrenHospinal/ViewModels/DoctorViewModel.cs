using ChildrenHospinal.Models.Diseases;
using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Specialities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.ViewModels
{
    public class DoctorViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<string> Degrees { get; set; }
        public SelectList Specilities { get; set; }
        public IEnumerable<int> items { get; set; }
    }
}
