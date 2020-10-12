using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.Institutions;
using Microsoft.AspNetCore.Mvc;

namespace ChildrenHospinal.Controllers
{
    public class InstitutionsController : Controller
    {
        private readonly IInstitutionRepository repo;
        public InstitutionsController(IInstitutionRepository r)
        {
            repo = r;
        }
        public ActionResult Index()
        {
            return View(repo.GetInstitutions());
        }

        public ActionResult Details(int id)
        {
            Institution user = repo.GetInstitution(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Institution user)
        {
            if (repo.AlreadyExists(user))
            {
                ModelState.AddModelError(nameof(user.Name), "Institution with such name already exists");
            }
            if (ModelState.IsValid)
            {
                repo.CreateInstitution(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            Institution user = repo.GetInstitution(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Institution user)
        {
            if (repo.AlreadyExists(user))
            {
                ModelState.AddModelError(nameof(user.Name),"Institution with such name already exists");
            }
            if (ModelState.IsValid)
            {
                repo.UpdateInstitution(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}