using ChildrenHospinal.Models.Diseases;
using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Patients;
using ChildrenHospinal.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ChildrenHospinal.Models.Vaccinations
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly IConfiguration _config;

        public VaccinationRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public VaccinationProcedure GetProcedure(int a, int b)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<VaccinationProcedure>(@"SELECT * 
                                                        From  VaccinationProcedure
                                                        Where PatientId = @a 
                                                        AND VaccinationId = @b; ", 
                                                        new { PatientId = a, VaccinationId = b }).FirstOrDefault();
            }

        }

        public IEnumerable<VaccinationViewModel> GetAllVaccinations()
        {
            var result = new List<VaccinationViewModel>();

            using (IDbConnection db = Connection)
            {
                var sql = db.Query<VaccinationProcedure, Patient, VaccinationPlan, VaccinationProcedure>(@"SELECT  VaccinationProcedure.Date AS Date, VaccinationProcedure.Done,
                                                                                                                    Patients.[Full name] AS FullName, VaccinationPlan.Name AS Name
                                                                                                            FROM VaccinationProcedure, Patients, VaccinationPlan
                                                                                                            WHERE VaccinationProcedure.PatientId = Patients.PatientId 
                                                                                                            AND VaccinationProcedure.VaccinationId = VaccinationPlan.VaccinationId",
                (procedure, patient, vac) =>
                {
                    var model = new VaccinationViewModel();

                    model.FullName = patient.FullName;
                    model.Date = procedure.Date;
                    model.Done = procedure.Done;
                    model.Name = vac.Name;
                    procedure.Patient = patient;
                    result.Add(model);

                    return procedure;

                }, splitOn: "Date,Done,FullName,Name");

                return result;
            }
        }

        public List<VaccinationList> GetVaccinationList(int idp)
        {
            var result = new List<VaccinationList>();

            using (IDbConnection db = Connection)
            {
                var sql = db.Query<VaccinationProcedure, Patient, VaccinationPlan, VaccinationProcedure>(@"SELECT VaccinationProcedure.Date AS Date, VaccinationProcedure.Done, Patients.[Full name] AS FullName, 
                                                                                                                   Patients.DOB, Patients.Address, VaccinationPlan.Name AS Name
                                                                                                           FROM VaccinationProcedure, Patients, VaccinationPlan
                                                                                                           WHERE VaccinationProcedure.PatientId = Patients.PatientId 
                                                                                                           AND VaccinationProcedure.VaccinationId = VaccinationPlan.VaccinationId 
                                                                                                           AND Patients.PatientId = @id",
                (procedure, patient, vac) =>
                {
                    var model = new VaccinationList();

                    model.FullName = patient.FullName;
                    model.DOB = patient.DOB;
                    model.Address = patient.Address;
                    model.ProcedureDate = procedure.Date;
                    model.ProcedureStatus = procedure.Done;
                    model.VaccinationName = vac.Name;
                    result.Add(model);
                    procedure.Patient = patient;

                    return procedure;

                } , new { id = idp }, splitOn: "Date, Done, FullName, Name");

                return result;
            }
        }

        public IEnumerable<RepeatedVaccinations> GetRepeatedVaccinations()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<RepeatedVaccinations>(@"SELECT Name as VaccinationName, Number as NumberOfRepetitions, Result as Vaccinations FROM DiseaseTable");
            }
        }

        public IEnumerable<CrossRequest> CrossRequest()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<CrossRequest>(@"SELECT * FROM
                                                (SELECT Name y, AGE, VaccinationId FROM VaccinationPlan) as s
                                                PIVOT
                                                (COUNT(VaccinationId)  for y in ([Коклюш], [Полиомелит], [Хиб-инфекция])) pv");
            }
        }

        public List<VaccinationPlanObject> GetVaccinationPlan()
        {
            var result = new List<VaccinationPlanObject>();

            using (IDbConnection db = Connection)
            {
                var sql = db.Query<VaccinationPlan>(@"SELECT * from VaccinationPlan;");
                foreach (var vac in sql)
                {
                    var model = new VaccinationPlanObject();
                    var age = vac.Age;
                    model.VaccinationId = vac.VaccinationId;
                    model.Name = vac.Name;
                    model.Age = age.Contains('d') ? TimeSpan.FromDays(Convert.ToInt32(age.Substring(0, age.Length-1))).TotalMilliseconds :
                                age.Contains('m') ? TimeSpan.FromDays(Convert.ToInt32(age.Substring(0, age.Length - 1)) * 30).TotalMilliseconds :
                                TimeSpan.FromDays(Convert.ToInt32(age.Substring(0, age.Length - 1)) * 30 * 12).TotalMilliseconds;
                    result.Add(model);
                }

                return result;
            }  
        }

        public void DeleteVaccination(int id)
        {
            throw new NotImplementedException();
        }
        public bool AlreadyExists(VaccinationProcedure procedure)
        {
            throw new NotImplementedException();
        }
    }
}
