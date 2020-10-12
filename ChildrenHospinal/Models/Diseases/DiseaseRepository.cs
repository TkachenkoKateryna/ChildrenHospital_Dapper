using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Diseases
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly IConfiguration _config;

        public DiseaseRepository(IConfiguration config)
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
        public void CreateDisease(Disease disease)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "INSERT INTO Diseases (Name, Code, Information, Infectivity, Deleted) VALUES(@Name, @Code, @Information, @Infectivity, 0)";
                db.Execute(sqlQuery, disease);
            }
        }

        public void DeleteDiasease(int id)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "UPDATE Diseases SET Deleted = 1 WHERE DiseaseId = @Id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Disease GetDesease(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Disease>("SELECT * FROM Diseases WHERE DiseaseId = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Disease> GetDisease()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Disease>("SELECT * FROM Diseases Where Deleted = 0").ToList();
            }
        }

        public void UpdateDisease(Disease disease)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "UPDATE Diseases SET Name = @Name, Code = @Code, Information = @Information, Infectivity = @Infectivity WHERE DiseaseId = @DiseaseId";
                db.Execute(sqlQuery, disease);
            }
        }

        public bool AlreadyExists(Disease disease)
        {
            using (IDbConnection db = Connection)
            {
                if (db.Query<string>("SELECT Name, Code From Diseases WHERE Name = @Name AND Code = @Code AND DiseaseId != @DiseaseId", new { disease.Name, disease.DiseaseId, disease.Code}).Count() < 1)
                {
                    return false;
                } 
                return true;
            }
        }
    }
}
