using ChildrenHospinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.TimeTable
{
    public interface ITableRepository
    {
        IEnumerable<TimeTable> GetTimeTable();
        IEnumerable<NumberOfVisits> GetNumberOfVisits();
        IEnumerable<TimeTable> GetTodaysTimeTable();
    }
}
