using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.Diseases;
using Microsoft.AspNetCore.Mvc;

namespace ChildrenHospinal.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly IDiseaseRepository repo;
        public DiseaseController(IDiseaseRepository r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            return View(repo.GetDisease());
        }

        public ActionResult Details(int id)
        {
            Disease user = repo.GetDesease(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Disease disease)
        {
            if (repo.AlreadyExists(disease))
            {
                ModelState.AddModelError(nameof(disease.Name), "Disease with name and code already exists");
            }
            if (ModelState.IsValid)
            {
                repo.CreateDisease(disease);
                return RedirectToAction("Index");
            }
            return View(disease);
        }

        public ActionResult Edit(int id)
        {
            Disease user = repo.GetDesease(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Disease disease)
        {

            if (repo.AlreadyExists(disease))
            {
                ModelState.AddModelError(nameof(disease.Name), "Disease with name and code already exists");
            }
            if (ModelState.IsValid)
            {
                repo.UpdateDisease(disease);
                return RedirectToAction("Index");
            }
            return View(disease);
        }
    }
}
