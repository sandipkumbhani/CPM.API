using Cpm.Api.Application.Interface;
using Cpm.Api.Domain.Interface;
using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Provider
{
    public class PatientDiagnosisService : IPatientDiagnosisService
    {
        private readonly IPatientDiagnosisRepository _repository;

        public PatientDiagnosisService(IPatientDiagnosisRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatientDiagnosisViewModel> Add(PatientDiagnosisViewModel model)
        {
            return await _repository.Add(model);
        }

        public async Task<int> Delete(int id)
        {
            var result = await _repository.GetByID(id);
            if (result != null)
            {
                result.IsQueue = false;
                await _repository.Delete(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<PatientDiagnosisViewModel>> GetAll()
        {
            return await _repository.GetAll();

        }

        public async Task<PatientDiagnosisViewModel> GetByID(int id)
        {
            return await _repository.GetByID(id);

        }

        public async Task Update(PatientDiagnosisViewModel model)
        {
            await _repository.Update(model);

        }
    }
}
