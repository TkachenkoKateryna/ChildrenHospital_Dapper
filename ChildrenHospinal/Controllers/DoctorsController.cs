using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Specialities;
using ChildrenHospinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChildrenHospinal.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecialityRepository _specialityRepository;
        public DoctorsController(IDoctorRepository doctorRepository, ISpecialityRepository specialityRepository)
        {
            _doctorRepository = doctorRepository;
            _specialityRepository = specialityRepository;
        }
        public ActionResult Index(string sortOrder, DoctorFilter filter = null, string query = null)
        {
            IEnumerable<Doctor> doctors = doctors = _doctorRepository.GetAllDoctors();

            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DegreeSortParm = sortOrder == "Degree" ? "degree_desc" : "Degree";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";


            if (!String.IsNullOrWhiteSpace(query))
            {
                doctors = doctors.Where(g => g.FullName.Contains(query));
            }

            if (filter.Speciality.HasValue)
            {
                doctors = _doctorRepository.FilterDoctorsBySpeciality(filter.Speciality);
            }

            if (filter.Degree != null)
            {
                doctors = doctors.Where(d => d.Degree == filter.Degree);
            }
                switch (sortOrder)
            {
                case "name_desc":
                    doctors = doctors.OrderByDescending(d => d.FullName);
                    break;
                case "Name":
                    doctors = doctors.OrderBy(d => d.FullName);
                    break;
                case "degree_desc":
                    doctors = doctors.OrderByDescending(d => d.Degree);
                    break;
                case "Degree":
                    doctors = doctors.OrderBy(d => d.Degree); ;
                    break;
                case "id_desc":
                    doctors = doctors.OrderByDescending(d => d.DoctorId);
                    break;
                case "Id":
                    doctors = doctors.OrderBy(d => d.DoctorId);
                    break;
                default:
                    break;
            }

            var viewModel = new DoctorListViewModel
            {
                Doctors = doctors,
                Specialities = _specialityRepository.GetSpecialities(),
                Degree = _doctorRepository.SelectDegrees(),
                SearchTerm = query
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(DoctorListViewModel viewModel)
        
        {
            return RedirectToAction("Index", "Doctors", new { @query = viewModel.SearchTerm });
        }

        public ActionResult Details(int id)
        {
            Doctor user = _doctorRepository.GetDoctor(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        public ActionResult Create()
        {
            var viewModel = new DoctorViewModel
            {
                Specilities = new SelectList(_specialityRepository.GetSpecialities(), "SpecialityId", "Name")
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor, IEnumerable<int> items)
        {
            if (_doctorRepository.IsDoctor(doctor))
            {
                ModelState.AddModelError(nameof(doctor.FullName), "Доктор с таким именем уже существует");
            }
            if (items.Count() == 0)
            {
                ModelState.AddModelError(nameof(doctor.Speciality), "Укажите специальность");
            }
            if (ModelState.IsValid)
            {
                _doctorRepository.CreateDoctor(doctor, items);
                
                return RedirectToAction("Index");
            }

            var viewModel = new DoctorViewModel
            {
                Doctor = doctor,
                Specilities = new SelectList(_specialityRepository.GetSpecialities(), "SpecialityId", "Name")
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            Doctor doctor = _doctorRepository.GetDoctor(id);

            var spec = _doctorRepository.GetSpecialitiesByDoctor(id);

            var viewModel = new DoctorViewModel
            {
                Degrees = _doctorRepository.SelectDegrees(),
                Specilities = new SelectList(_specialityRepository.GetSpecialities(), "SpecialityId", "Name"),
                Doctor = doctor
            };

            foreach (var sp in spec)
            {
                foreach (var s in viewModel.Specilities)
                {
                    if (Convert.ToInt32(s.Value) == sp)
                    {
                        s.Selected = true;
                    }
                }
            }

            if (doctor != null)
            {
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Doctor doctor, IEnumerable<int> items)
        {
            var spec = _doctorRepository.GetSpecialitiesByDoctor(doctor.DoctorId);

            if (_doctorRepository.IsDoctor(doctor))
            {
                ModelState.AddModelError(nameof(doctor.FullName), "Доктор с таким именем уже существует");
            }
            if (ModelState.IsValid)
            {
                _doctorRepository.UpdateDoctor(doctor);

                return RedirectToAction("Index");
            } 

            var viewModel = new DoctorViewModel
            {
                Doctor = doctor,
                Specilities = new SelectList(_specialityRepository.GetSpecialities(), "SpecialityId", "Name"),
                Degrees = _doctorRepository.SelectDegrees()
            };

            foreach (var sp in spec)
            {
                foreach (var s in viewModel.Specilities)
                {
                    if (Convert.ToInt32(s.Value) == sp)
                    {
                        s.Selected = true;
                    }
                }
            }

            return View(viewModel);
        }
    }
}