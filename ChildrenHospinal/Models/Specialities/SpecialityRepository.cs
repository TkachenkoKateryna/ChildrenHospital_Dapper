using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Specialities
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly IConfiguration _config;

        public SpecialityRepository(IConfiguration config)
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

        public bool AlreadyExists(Speciality speciality)
        {
            throw new NotImplementedException();
        }

        public void CreateSpeciality(int a, int b)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES(@SpecialityId, @DoctorId)";
                db.Execute(sqlQuery, new { SpecialityId = a, DoctorId = b });
            }
        }

        public void DeleteSpeciality(int id)
        {
            throw new NotImplementedException();
        }

        public Speciality GetSpeciality(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Speciality>("SELECT * FROM Specialities WHERE SpecialityId = @id ", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Speciality> GetSpecialities()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Speciality>("SELECT * FROM Specialities");
            }
        }

        public void UpdateSpeciality(Speciality speciality)
        {
            throw new NotImplementedException();
        }
    }
}
