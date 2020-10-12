using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.Vaccinations;
using ChildrenHospinal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChildrenHospinal.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly IVaccinationRepository repo;
        public VaccinationController(IVaccinationRepository r)
        {
            repo = r;
        }

        public IActionResult ShowVaccinations(VaccinationFilter filter = null)
        {
            var vaccinations = repo.GetAllVaccinations();

            if (filter.Done == true)
            {
                vaccinations = vaccinations.Where(v => v.Done == true);
            }
            if (filter.Done == false)
            {
                vaccinations = vaccinations.Where(v => v.Done == false);
            }

            var viewModel = new RandomVaccinationViewModel
            {
                Vaccinations = vaccinations,
            };

            return View(viewModel);
        }


        public IActionResult ShowCrossRequest()
        {
            return View(repo.CrossRequest());
        }

        public IActionResult ShowRepeatedVaccinations()
        {
            return View(repo.GetRepeatedVaccinations());
        }
    }
}