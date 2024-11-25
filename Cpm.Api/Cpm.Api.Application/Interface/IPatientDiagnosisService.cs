using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Interface
{
    public interface IPatientDiagnosisService
    {
        Task<IEnumerable<PatientDiagnosisViewModel>> GetAll();
        Task<PatientDiagnosisViewModel> GetByID(int id);
        Task<PatientDiagnosisViewModel> Add(PatientDiagnosisViewModel model);
        Task Update(PatientDiagnosisViewModel model);
        Task<int> Delete(int id);
    }
}
