using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Domain.Interface
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorMasterModel>> GetAll();
        Task<DoctorMasterModel> GetByID(int id);
        Task<DoctorMasterModel> AddDoctor(DoctorMasterModel model);
        Task UpdateDoctor(DoctorMasterModel model);
        Task DeleteDoctor(DoctorMasterModel model);
    }
}
