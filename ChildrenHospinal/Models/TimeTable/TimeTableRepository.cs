using ChildrenHospinal.Models.Doctors;
using ChildrenHospinal.Models.Specialities;
using ChildrenHospinal.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.TimeTable
{
    public class TimeTableRepository : ITableRepository
    {
        private readonly IConfiguration _config;

        public TimeTableRepository(IConfiguration config)
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
        public IEnumerable<TimeTable> GetTimeTable()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<TimeTable, Doctor, Speciality, TimeTable>(@"SELECT TimeTable.StartTime, TimeTable.EndTime, TimeTable.Date, TimeTable.Room, Doctors.[Full name] as FullName, Specialities.Name
                                                                            FROM TimeTable 
                                                                            LEFT JOIN  DoctorSpeciality 
                                                                            ON TimeTable.DoctorSpecialityId = DoctorSpeciality.DoctorSpecialityId
                                                                            LEFT JOIN Doctors
                                                                            ON DoctorSpeciality.DoctorId = Doctors.DoctorId
                                                                            LEFT JOIN Specialities
                                                                            ON DoctorSpeciality.SpecialityId = Specialities.SpecialityId;", 
                    (table, doctor, speciality) => {
                        table.Doctor = doctor;
                        table.Speciality = speciality;

                        return table;
                    }, splitOn: "FullName, Name").ToList();
            }
        }

        public IEnumerable<TimeTable> GetTodaysTimeTable()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<TimeTable, Doctor, Speciality, TimeTable>(@"SELECT TimeTable.StartTime, TimeTable.EndTime, TimeTable.Date, TimeTable.Room, Doctors.[Full name] as FullName, Specialities.Name
                                                                            FROM TimeTable 
                                                                            LEFT JOIN  DoctorSpeciality 
                                                                            ON TimeTable.DoctorSpecialityId = DoctorSpeciality.DoctorSpecialityId
                                                                            LEFT JOIN Doctors
                                                                            ON DoctorSpeciality.DoctorId = Doctors.DoctorId
                                                                            LEFT JOIN Specialities
                                                                            ON DoctorSpeciality.SpecialityId = Specialities.SpecialityId
                                                                            WHERE TimeTable.Date = '2019-12-24';",
                    (table, doctor, speciality) => {
                        table.Doctor = doctor;
                        table.Speciality = speciality;

                        return table;
                    }, splitOn: "FullName, Name").ToList();
            }
        }

        public IEnumerable<NumberOfVisits> GetNumberOfVisits()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<NumberOfVisits>(@"SELECT DOCTORS.[Full name] as FullName,COUNT(TimeTable.TableId) as Number, Specialities.Name FROM TIMETABLE,DoctorSpeciality,Doctors, Specialities
                                                    WHERE TIMETABLE.DOCTORSPECIALITYID = DOCTORSPECIALITY.DOCTORSPECIALITYID AND DOCTORSPECIALITY.DOCTORID = Doctors.DoctorId and  DOCTORSPECIALITY.SpecialityId = Specialities.SpecialityId
                                                    AND TIMETABLE.DATE = CONVERT(date, GETDATE())
                                                    GROUP BY DOCTORS.[Full name],  Specialities.Name ;");
            }
        }
    }
}
