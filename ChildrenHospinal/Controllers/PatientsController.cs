using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenHospinal.Models.Patients;
using Microsoft.AspNetCore.Mvc;
using FastReport.Web;
using System.Text;
using System.Data;
using FastReport;
using ChildrenHospinal.ViewModels;
using ChildrenHospinal.Services;
using ChildrenHospinal.Models.Vaccinations;

namespace ChildrenHospinal.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository repo;
        private readonly IPatientsService _service;
        private readonly IVaccinationRepository _rep;
        public PatientsController(IPatientRepository r, IPatientsService serv, IVaccinationRepository rep)
        {
            repo = r;
            _service = serv;
            _rep = rep;
        }

        public IActionResult Index()
        {
            return View(repo.GetPatients());
        }

        public IActionResult PatientReport()
        {
            var Report = new Report();
            Report.Report.Load(@"wwwroot\Reports\PatientsReport.frx");
            return View(Report);
        }
        public IActionResult PersonalPlan(int id)
        {
            var viewModel = new PersonalPlanViewMode
            {
                Plan = _service.Plan(id).OrderBy(d => d.Date),
                Patient = repo.GetPatient(id),
            };
            return View(viewModel);
        }

        public async Task<IActionResult> SendMessage()
        {
            EmailService emailService = new EmailService();
            var patients = _service.Notification();
            foreach(var pat in patients)
            {
                await emailService.SendEmailAsync(pat.Email, "Напоминание", "Вам нужно сделать привику. Перейдите в персональный план прививок для уточнения информации. С уважением, ваш педиатр");
            }
            return RedirectToAction("Index");
        }

    }
}