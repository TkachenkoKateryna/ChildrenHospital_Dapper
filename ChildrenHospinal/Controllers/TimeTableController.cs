using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.TimeTable;
using Microsoft.AspNetCore.Mvc;

namespace ChildrenHospinal.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly ITableRepository repo;

        public TimeTableController(ITableRepository r)
        {
            repo = r;
        }

        public IActionResult Index()
        {
            return View(repo.GetTimeTable().GroupBy(t => t.Date));
        }

        public IActionResult Index2()
        {
            return View(repo.GetNumberOfVisits());
        }
    }
}