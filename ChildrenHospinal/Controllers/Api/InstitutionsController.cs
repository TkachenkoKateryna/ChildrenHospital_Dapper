using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.Institutions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChildrenHospinal.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly IInstitutionRepository _service;

        public InstitutionsController(IInstitutionRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Institution> Get()
        {
            return _service.GetInstitutions();
        }

        [HttpPost]
        public IActionResult Delete(int institutionId)
        {
            _service.DeleteInstitution(institutionId);

            return RedirectToAction("Index");
        }
    }
}