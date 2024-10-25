using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Interface
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicMasterModel>> GetAllClinic();
        Task<ClinicMasterModel> GetByID(int id);
        Task<ClinicMasterModel> AddClinic(ClinicMasterModel model);
        Task UpdateClinic(ClinicMasterModel model);
        Task<int> DeleteClinic(int id);
    }
}
