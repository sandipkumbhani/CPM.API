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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientrepository;

        public PatientService(IPatientRepository patientrepository)
        {
            _patientrepository = patientrepository;
        }
        public async Task<PatientViewModel> AddPatient(PatientViewModel model)
        {
            return await _patientrepository.AddPatient(model);
        }
        public async Task<int> DeletePatient(int id)
        {
            var result = await _patientrepository.GetByID(id);
            if (result != null)
            {
                await _patientrepository.DeletePatient(result);
                return 1;
            }
            return 0;
        }
        public async Task<IEnumerable<PatientViewModel>> GetAllPatient()
        {
            return await _patientrepository.GetAll();
        }
        public async Task<PatientViewModel> GetByID(int id)
        {
            return await _patientrepository.GetByID(id);
        }
        public async Task UpdatePatient(PatientViewModel model)
        {
            await _patientrepository.UpdatePatient(model);
        }
    }
}
