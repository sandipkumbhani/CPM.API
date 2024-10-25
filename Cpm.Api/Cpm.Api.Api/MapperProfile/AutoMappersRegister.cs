using AutoMapper;
using Cpm.Api.Api.RequestDto;
using Cpm.Api.Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cpm.Api.Api.MapperProfile
{
    public class AutoMappersRegister : Profile
    {
        public AutoMappersRegister()
        {
            CreateMap<ClinicMasterModel, ClinicDto>();
            CreateMap<ClinicDto, ClinicMasterModel>();
            CreateMap<DoctorMasterModel, DoctorDto>();
            CreateMap<DoctorDto, DoctorMasterModel>();
        }
    }
}
