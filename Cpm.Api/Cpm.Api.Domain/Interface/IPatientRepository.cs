using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Domain.Interface
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientViewModel>> GetAll();
        Task<PatientViewModel> GetByID(int id);
        Task<PatientViewModel> AddPatient(PatientViewModel model);
        Task UpdatePatient(PatientViewModel model);
        Task DeletePatient(PatientViewModel model);
    }
}
