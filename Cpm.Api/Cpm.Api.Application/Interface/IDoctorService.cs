using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Interface
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorMasterModel>> GetAll();
        Task<DoctorMasterModel> GetByID(int id);
        Task<DoctorMasterModel> AddDoctor(DoctorMasterModel model);
        Task UpdateDoctor(DoctorMasterModel model);
        Task<int> DeleteDoctor(int id);
    }
}
