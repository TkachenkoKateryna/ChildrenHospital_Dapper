using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Institutions;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration _config;

        public PatientRepository(IConfiguration config)
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

        public IEnumerable <Patient> GetPatients()
        {
            using (IDbConnection db = Connection)
            {
                 return  db.Query<Patient, Institution, Doctor, Patient>(@"SELECT Patients.PatientId, Patients.[Full name] AS FullName , Patients.DOB,Patients.Address, Institutions.Name, Doctors.[Full name] AS FullName
                                           FROM Patients, Institutions, Doctors
                                           Where Patients.InstitutionId = Institutions.InstitutionId AND
                                           Patients.DoctorId = Doctors.DoctorId ", (patient, institution, doctor) => {
                   
                        if (institution == null)
                        {
                            institution = new Institution { Name = ""};
                        }
                        patient.Institution = institution;
                    
                        if (doctor == null)
                        {
                            doctor = new Doctor { FullName = ""};
                        }
                        patient.Doctor = doctor;

                        return patient;
                }, splitOn: "Name, FullName").ToList();
            }
        }

        public Patient GetPatient(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Patient, Institution, Doctor, Patient>(@"SELECT Patients.PatientId, Patients.[Full name] AS FullName , Patients.DOB, Patients.Address, Patients.Email, Institutions.Name, Doctors.[Full name] AS FullName
                                           FROM Patients, Institutions, Doctors
                                           Where Patients.InstitutionId = Institutions.InstitutionId AND
                                           Patients.DoctorId = Doctors.DoctorId AND PatientId = @id",(patient, institution, doctor) =>
                {

                    if (institution == null)
                    {
                        institution = new Institution { Name = "" };
                    }
                    patient.Institution = institution;

                    if (doctor == null)
                    {
                        doctor = new Doctor { FullName = "" };
                    }
                    patient.Doctor = doctor;
                    return patient;
                }, new { id },splitOn: "Name, FullName").FirstOrDefault();
            }
        }

        public IEnumerable<Patient> GetUnnotifiedPatient()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Patient>(@"SELECT Patients.PatientId, Patients.[Full name] AS FullName , Patients.DOB, Patients.Address, Patients.Email
                                           FROM Patients
										   EXCEPT  (SELECT Patients.PatientId, Patients.[Full name] AS FullName , Patients.DOB, Patients.Address, Patients.Email
										   from patients, VaccinationProcedure
										   where Patients.PatientId = VaccinationProcedure.PatientId AND
										   VaccinationProcedure.Notified = 1);");
            }
        }

        
    }
}
