using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Institutions
{
    public interface IInstitutionRepository
    {
        void CreateInstitution(Institution institution);
        void DeleteInstitution(int id);
        Institution GetInstitution(int id);
        IEnumerable<Institution> GetInstitutions();
        void UpdateInstitution(Institution institution);
        bool AlreadyExists(Institution institution);
    }
}
