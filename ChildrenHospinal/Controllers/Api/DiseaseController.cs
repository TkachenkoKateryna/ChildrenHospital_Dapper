using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.Diseases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChildrenHospinal.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseRepository _service;

        public DiseaseController(IDiseaseRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Disease> Get()
        {
            return _service.GetDisease();
        }

        [HttpPost]
        public IActionResult Delete(int diseaseId)
        {
            _service.DeleteDiasease(diseaseId);

            return RedirectToAction("Index");
        }
    }
}