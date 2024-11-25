using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Domain.Interface
{
    public interface IPatientDiagnosisRepository
    {
        Task<IEnumerable<PatientDiagnosisViewModel>> GetAll();
        Task<PatientDiagnosisViewModel> GetByID(int id);
        Task<PatientDiagnosisViewModel> Add(PatientDiagnosisViewModel model);
        Task Update(PatientDiagnosisViewModel model);
        Task Delete(PatientDiagnosisViewModel model);
    }
}
