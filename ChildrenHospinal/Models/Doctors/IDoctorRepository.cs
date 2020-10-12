using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Doctors
{
    public interface IDoctorRepository
    {
        void CreateDoctor(Doctor doctor,IEnumerable<int> selectedSpecialities);
        void DeleteDoctor(int id);
        Doctor GetDoctor(int id);
        IEnumerable<Doctor> GetAllDoctors();
        void UpdateDoctor(Doctor doctor);
        IEnumerable<string> SelectDegrees();
        bool IsDoctor(Doctor doctor);
        IEnumerable<Doctor> OrderDoctorsByNameAsc();
        IEnumerable<Doctor> FilterDoctorsBySpeciality(int? id);
        IEnumerable<Doctor> OrderDoctorsByNameDesc();
        IEnumerable<Doctor> OrderDoctorsByDegreeAsc();
        IEnumerable<Doctor> OrderDoctorsByDegreeDesc();
        IEnumerable<int> GetSpecialitiesByDoctor(int id);
        int GetDoctorTimeTable(int id);
        int GetPatientsByDoctor(int id);
    }
}
