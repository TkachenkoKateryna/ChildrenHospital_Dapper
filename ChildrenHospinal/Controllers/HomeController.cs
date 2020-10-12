using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChildrenHospinal.Models;
using ChildrenHospinal.Models.TimeTable;

namespace ChildrenHospinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITableRepository repo;

        public HomeController(ITableRepository r)
        {
            repo = r;
        }
        public IActionResult Index()
        {
            return View(repo.GetTodaysTimeTable().ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
