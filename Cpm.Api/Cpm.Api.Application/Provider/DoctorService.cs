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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _repository = doctorRepository;
        }
        public async Task<DoctorMasterModel> AddDoctor(DoctorMasterModel model)
        {
            return await _repository.AddDoctor(model);
        }

        public async Task<int> DeleteDoctor(int id)
        {
           var result = await _repository.GetByID(id);
            if (result != null)
            {
                result.IsActive = false;
                await _repository.DeleteDoctor(result);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<DoctorMasterModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<DoctorMasterModel> GetByID(int id)
        {
           return await _repository.GetByID(id);
        }

        public async Task UpdateDoctor(DoctorMasterModel model)
        {
            await _repository.UpdateDoctor(model);
        }
    }
}
