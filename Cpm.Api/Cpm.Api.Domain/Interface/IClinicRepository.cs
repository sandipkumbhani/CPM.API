using Cpm.Api.Domain.Model;

namespace Cpm.Api.Domain.Interface
{
    public interface IClinicRepository
    {
        Task<IEnumerable<ClinicMasterModel>> GetAllClinic();
        Task<ClinicMasterModel> GetByID(int id);
        Task<ClinicMasterModel> AddClinic(ClinicMasterModel model);
        Task UpdateClinic(ClinicMasterModel model);
        Task DeleteClinic(ClinicMasterModel model);
    }
}
