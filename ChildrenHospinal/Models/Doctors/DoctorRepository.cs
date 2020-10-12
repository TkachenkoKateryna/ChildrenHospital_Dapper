using ChildrenHospinal.Models.Specialities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IConfiguration _config;

        public DoctorRepository(IConfiguration config)
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

        public void CreateDoctor(Doctor doctor, IEnumerable<int> selectedSpecialities)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "INSERT INTO Doctors ([Full name], [Phone number], Degree, Deleted) " +
                    "VALUES(@FullName, @PhoneNumber, @Degree, 0)";

                db.Execute(sqlQuery, doctor);

                var id = db.Query<int>("SELECT MAX(DoctorId) FROM Doctors");
                foreach (var speciality in selectedSpecialities)
                {
                    var sqlQuery1 = "INSERT INTO DoctorSpeciality (SpecialityId, DoctorId)" +
                        " VALUES(@SpecialityId, @DoctorId)";

                    db.Execute(sqlQuery1, new { SpecialityId = speciality, DoctorId = id});
                }
            }
        }

        public IEnumerable<int> GetSpecialitiesByDoctor(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<int>(@"SELECT Specialities.SpecialityId FROM DoctorSpeciality, Doctors, Specialities
                                          WHERE DoctorSpeciality.DoctorId = Doctors.DoctorId  
                                          AND DoctorSpeciality.SpecialityId = Specialities.SpecialityId
                                          AND Doctors.DoctorId = @id; ", 
                                          new {id});
            }
        }

        public void DeleteDoctor(int id)
        {
           
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "UPDATE Doctors SET Deleted = 1 WHERE DoctorId = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Doctor GetDoctor(int id)
        {
            using (IDbConnection db = Connection)
            {
                var result = new List<Doctor>();

                var sql =  db.Query<Doctor, Speciality, Doctor>(@"SELECT Doctors.DoctorId, Doctors.[Full name] AS FullName, Doctors.[Phone number] 
                                                                  AS PhoneNumber, Doctors.Degree, Specialities.Name 
                                                                  FROM Doctors, Specialities, DoctorSpeciality
                                                                  WHERE Doctors.DoctorId = DoctorSpeciality.DoctorId 
                                                                  AND Specialities.SpecialityId = DoctorSpeciality.SpecialityId 
                                                                  AND Doctors.DoctorId = @id",
                (doctor, speciality) =>
                {
                    if (speciality == null)
                    {
                        speciality = new Speciality { Name = "" };
                    }
                    if (doctor == null)
                    {
                        doctor = new Doctor { FullName = "", Degree = "", PhoneNumber = "" };
                    }

                    if (!result.Any(d => d.DoctorId == doctor.DoctorId))
                    {
                        result.Add(doctor);
                        doctor.Speciality = new List<Speciality>();

                        doctor.Speciality.Add(speciality);
                        doctor.srt += speciality.Name;
                    }
                    else
                    {
                        result.FirstOrDefault(d => d.DoctorId == doctor.DoctorId).Speciality.Add(speciality);
                        result.FirstOrDefault(d => d.DoctorId == doctor.DoctorId).srt += speciality.Name;
                    }

                    return doctor;
                }, new { id }, splitOn: "Name");

                return result.FirstOrDefault();
            }
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var result = new List<Doctor>();

            using (IDbConnection db = Connection)
            {
                var sql =  db.Query<Doctor,Speciality,Doctor>(@"SELECT Doctors.DoctorId, Doctors.[Full name] AS FullName, Doctors.[Phone number] AS PhoneNumber,
                                                                       Doctors.Degree, Specialities.Name 
                                                                FROM Doctors, Specialities, DoctorSpeciality
                                                                WHERE Doctors.DoctorId = DoctorSpeciality.DoctorId 
                                                                AND Specialities.SpecialityId = DoctorSpeciality.SpecialityId 
                                                                AND Deleted = 0;",
                (doctor, speciality) =>
                {
                    if (speciality == null)
                    {
                        speciality = new Speciality { Name = "" };
                    }
                    if (doctor == null)
                    {
                        doctor = new Doctor { FullName = "", Degree = "", PhoneNumber = "" };
                    }

                    if (!result.Any(d => d.DoctorId == doctor.DoctorId))
                    {
                        result.Add(doctor);
                        doctor.Speciality =  new List<Speciality>();

                        doctor.Speciality.Add(speciality);
                        doctor.srt += speciality.Name;
                    } 
                    else
                    {
                        result.FirstOrDefault(d => d.DoctorId == doctor.DoctorId).Speciality.Add(speciality);
                        result.FirstOrDefault(d => d.DoctorId == doctor.DoctorId).srt += speciality.Name;
                    }
                    
                    return doctor;
                }, splitOn: "Name");

                return result;
            }
        }

        public void UpdateDoctor(Doctor doctor)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "UPDATE Doctors SET [Full name] = @FullName, [Phone number] = @PhoneNumber, Degree = @Degree WHERE DoctorId = @DoctorId";
                db.Execute(sqlQuery, doctor);
            }
        }

        public IEnumerable<string> SelectDegrees()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<string>("SELECT DISTINCT Degree FROM Doctors");
             }
        }

        public bool IsDoctor(Doctor doctor)
        {
            using (IDbConnection db = Connection)
            {
                if (db.Query<string>("SELECT [Full name] " +
                                     "From Doctors " +
                                     "WHERE [Full name] = @FullName " +
                                     "AND DoctorId != @DoctorId",
                                     new { doctor.FullName, doctor.DoctorId }).Count() < 1)
                {
                    return false;
                }
                return true;
            }
        }

        public IEnumerable<Doctor> OrderDoctorsByNameAsc()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Doctor>("SELECT DoctorId, [Full name] AS FullName, [Phone number] AS PhoneNumber, Degree " +
                                        "FROM Doctors Where Deleted = 0 " +
                                        "ORDER BY [Full name]")
                                         .ToList();
            }
        }

        public IEnumerable<Doctor> OrderDoctorsByNameDesc()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Doctor>("SELECT DoctorId, [Full name] AS FullName, [Phone number] AS PhoneNumber, Degree " +
                                        "FROM Doctors" +
                                        "Where Deleted = 0 " +
                                        "ORDER BY [Full name] DESC")
                                        .ToList();
            }
        }

        public IEnumerable<Doctor> OrderDoctorsByDegreeDesc()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Doctor>("SELECT DoctorId, [Full name] AS FullName, [Phone number] AS PhoneNumber, Degree " +
                                        "FROM Doctors Where Deleted = 0" +
                                        "ORDER BY Degree DESC")
                                         .ToList();
            }
        }

        public IEnumerable<Doctor> OrderDoctorsByDegreeAsc()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Doctor>("SELECT DoctorId, [Full name] AS FullName, [Phone number] AS PhoneNumber, Degree" +
                                        "FROM Doctors Where Deleted = 0" +
                                        "ORDER BY Degree")
                                        .ToList();
            }
        }

        public IEnumerable<Doctor> FilterDoctorsBySpeciality(int? id)
        {
            var result = new List<Doctor>();
            using (IDbConnection db = Connection)
            {
                var sql = db.Query<Doctor, Speciality, Doctor>(@"SELECT Doctors.DoctorId, Doctors.[Full name] AS FullName, 
                                                                        Doctors.[Phone number] AS PhoneNumber, Doctors.Degree, Specialities.Name 
                                                                FROM Doctors, Specialities, DoctorSpeciality
                                                                WHERE Doctors.DoctorId = DoctorSpeciality.DoctorId 
                                                                AND Specialities.SpecialityId = DoctorSpeciality.SpecialityId
                                                                AND Specialities.SpecialityId = @id",
            (doctor, speciality) =>
            {
                if (speciality == null)
                {
                    speciality = new Speciality { Name = "" };
                }
                if (doctor == null)
                {
                    doctor = new Doctor { FullName = "", Degree = "", PhoneNumber = "" };
                }


                if (!result.Any(d => d.DoctorId == doctor.DoctorId))
                {
                    result.Add(doctor);
                    doctor.Speciality = new List<Speciality>();

                    doctor.Speciality.Add(speciality);
                    doctor.srt += speciality.Name +  Environment.NewLine;
                }
                else
                {
                    result.FirstOrDefault(d => d.DoctorId == doctor.DoctorId).Speciality.Add(speciality);
                    result.FirstOrDefault(d => d.DoctorId == doctor.DoctorId).srt += speciality.Name;
                }

                return doctor;

            }, new { id },  splitOn: "Name");
                return result;
            }
        }

        public IEnumerable<Doctor> GetDoctorsByDegree(string degree)
        {
            var result = new List<Doctor>();
            using (IDbConnection db = Connection)
            {
                var sql = db.Query<Doctor, Speciality, Doctor>(@"SELECT Doctors.DoctorId, Doctors.[Full name] AS FullName, Doctors.[Phone number] AS PhoneNumber,
                                                                        Doctors.Degree, Specialities.Name 
                                                                 FROM Doctors, Specialities, DoctorSpeciality
                                                                 WHERE Doctors.DoctorId = DoctorSpeciality.DoctorId 
                                                                 AND Specialities.SpecialityId = DoctorSpeciality.SpecialityId
                                                                 AND Doctors.Degree = @degree", (doctor, speciality) =>
                {
                    if (speciality == null)
                    {
                        speciality = new Speciality { Name = "" };
                    }
                    if (doctor == null)
                    {
                        doctor = new Doctor { FullName = "", Degree = "", PhoneNumber = "" };
                    }


                    if (!result.Any(d => d.DoctorId == doctor.DoctorId))
                    {
                        result.Add(doctor);
                        doctor.Speciality = new List<Speciality>();

                        doctor.Speciality.Add(speciality);
                        doctor.srt += speciality.Name + Environment.NewLine;
                    }
                    else
                    {
                        result.FirstOrDefault(d => d.DoctorId == doctor.DoctorId).Speciality.Add(speciality);
                        result.FirstOrDefault(d => d.DoctorId == doctor.DoctorId).srt += speciality.Name;
                    }

                    return doctor;
                }, new { degree }, splitOn: "Name");

                return result;
            }
        }

        public int GetPatientsByDoctor(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<int>(@"SELECT COUNT(*) FROM Patients, Doctors
                                    WHERE Patients.DoctorId = Doctors.DoctorId
                                    AND Doctors.DoctorId = @id;",
                                    new { id }).FirstOrDefault();
            }
        }

        public int GetDoctorTimeTable(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<int>(@" SELECT COUNT(*) FROM TimeTable
                                        LEFT JOIN DoctorSpeciality
                                        ON TimeTable.DoctorSpecialityId = DoctorSpeciality.DoctorSpecialityId 
                                        LEFT JOIN Doctors
                                        ON  DoctorSpeciality.DoctorId = Doctors.DoctorId
                                        WHERE Doctors.DoctorId = @id 
                                        AND Date >= (CONVERT(date, GETDATE()))",
                                        new { id }).FirstOrDefault();
            }
        }
    }
}
