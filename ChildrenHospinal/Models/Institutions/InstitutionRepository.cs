using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Institutions
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly IConfiguration _config;

        public InstitutionRepository(IConfiguration config)
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

        public void CreateInstitution(Institution institution)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "INSERT INTO Institutions (Name, Address, [Phone number] , Director, Deleted) VALUES(@Name, @Address, @PhoneNumber, @Director, 0)";
                db.Execute(sqlQuery, institution);
            }
        }

        public void DeleteInstitution(int id)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "UPDATE Institutions SET Deleted = 1 WHERE InstitutionId = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Institution GetInstitution(int id)
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Institution>("SELECT InstitutionId, Name, Address, [Phone number] AS PhoneNumber, Director FROM Institutions WHERE InstitutionId = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Institution> GetInstitutions()
        {
            using (IDbConnection db = Connection)
            {
                return db.Query<Institution>("SELECT InstitutionId, Name, Address, [Phone number] AS PhoneNumber, Director  FROM Institutions Where Deleted = 0").ToList();
            }
        }

        public void UpdateInstitution(Institution institution)
        {
            using (IDbConnection db = Connection)
            {
                var sqlQuery = "UPDATE Institutions SET Name = @Name, Address = @Address, [Phone number] = @PhoneNumber, Director = @Director WHERE InstitutionId = @InstitutionId";
                db.Execute(sqlQuery, institution);
            }
        }

        public bool AlreadyExists(Institution institution)
        {
            using (IDbConnection db = Connection)
            {

                if(db.Query<string>("SELECT Name From Institutions WHERE Name = @Name AND InstitutionId != @InstitutionId", new {institution.Name, institution.InstitutionId }).Count() < 1)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
