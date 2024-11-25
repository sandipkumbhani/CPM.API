using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Interface
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientViewModel>> GetAllPatient();
        Task<PatientViewModel> GetByID(int id);
        Task<PatientViewModel> AddPatient(PatientViewModel model);
        Task UpdatePatient(PatientViewModel model);
        Task<int> DeletePatient(int id);
    }
}
