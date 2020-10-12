using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.Patients;
using ChildrenHospinal.Models.Vaccinations;
using ChildrenHospinal.Services;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChildrenHospinal.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private IConverter _converter;
        private readonly IVaccinationRepository _repo;
        private readonly IPatientRepository _repo1;

        public PdfCreatorController(IConverter converter, IVaccinationRepository repo, IPatientRepository repo1)
        {
            _converter = converter;
            _repo = repo;
            _repo1 = repo1;
        }

        [Route("createpdfforpatients")]
        public IActionResult CreatePDFForPatients()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = $"D:\\Patients_Report_{DateTime.Now.Second.ToString()}.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLStringForPatients(_repo1.GetPatients().ToList()),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Страница [page] из [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Left = "Дата " + DateTime.Now.Date.ToShortDateString() }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return Ok("Отчет загружен в папку D");
        }
        [Route("createpdfforvaccinations")]
        public IActionResult CreatePDFForVaccinations(int id)
        {
            var lists = _repo.GetVaccinationList(id).ToList();

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = $"D:\\Vaccination_List_Report_{DateTime.Now.Second.ToString()}.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLStringForVaccinations(lists),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Страница [page] из [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Left = "Дата " + DateTime.Now.Date.ToShortDateString() }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return Ok("Отчет загружен в папку D");
        }
    }
}