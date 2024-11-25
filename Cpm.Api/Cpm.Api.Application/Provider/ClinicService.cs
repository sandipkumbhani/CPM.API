using Cpm.Api.Application.Interface;
using Cpm.Api.Domain.Interface;
using Cpm.Api.Domain.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Provider
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _repository;
        public ClinicService(IClinicRepository repository)
        {
            _repository = repository;
        }
        public async Task<ClinicMasterModel> AddClinic(ClinicMasterModel model)
        {
                return await _repository.AddClinic(model);
        }

        public async Task<int> DeleteClinic(int id)
        {
            var result = await _repository.GetByID(id);
            if(result != null)
            {
                result.IsActive = false;
                await _repository.DeleteClinic(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<ClinicMasterModel>> GetAllClinic()
        {
            return await _repository.GetAllClinic();
        }

        public async Task<ClinicMasterModel> GetByID(int id)
        {
            return await _repository.GetByID(id);
        }

        public async Task UpdateClinic(ClinicMasterModel model)
        {
           await _repository.UpdateClinic(model);
        }
    }
}
