using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Specialities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.TimeTable
{
    public class TimeTable
    {
        public Doctor Doctor{ get; set; }
        public Speciality Speciality { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DateTime Date { get; set; }

        public int Room { get; set; }
    }
}
