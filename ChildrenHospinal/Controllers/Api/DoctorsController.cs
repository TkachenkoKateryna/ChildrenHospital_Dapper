using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models;
using ChildrenHospinal.Models.Doctors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChildrenHospinal.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _service;

        public DoctorsController(IDoctorRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
            return _service.GetAllDoctors();
        }

        [HttpPost]
        public IActionResult Delete(int doctorId)
        {
            var P = _service.GetPatientsByDoctor(doctorId);
            var T = _service.GetDoctorTimeTable(doctorId);

            if (P != 0 || T != 0)
            {
                return BadRequest();
            }

            _service.DeleteDoctor(doctorId);

            return RedirectToAction("Index");
        }
    }
}