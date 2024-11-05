using AutoMapper;
using Cpm.Api.Contracts.RequestDtos;
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
            CreateMap<LoginModel, LoginDto>();
            CreateMap<LoginDto, LoginModel>();
            CreateMap<SkillMasterModel, SkillDto>();
            CreateMap<SkillDto, SkillMasterModel>();
        }
    }
}
