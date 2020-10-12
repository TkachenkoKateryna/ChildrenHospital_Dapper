using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Specialities
{
    public interface ISpecialityRepository
    {
        void CreateSpeciality(int a, int b);
        void DeleteSpeciality(int id);
        Speciality GetSpeciality(int id);
        IEnumerable<Speciality> GetSpecialities();
        void UpdateSpeciality(Speciality speciality);
        bool AlreadyExists(Speciality speciality);
    }
}
