using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenHospinal.Models.Diseases
{
    public interface IDiseaseRepository
    {
        void CreateDisease(Disease disease);
        void DeleteDiasease(int id);
        Disease GetDesease(int id);
        IEnumerable<Disease> GetDisease();
        void UpdateDisease(Disease user);
        bool AlreadyExists(Disease disease);
    }
}
