using AutoMapper;
using Cpm.Api.Application.Interface;
using Cpm.Api.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Cpm.Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClinicService _clinicService;
        private readonly IDoctorService _doctorService;
        public RegisterController(IClinicService clinicService, IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _clinicService = clinicService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<RegisterViewModel>> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                int cid;
                var clinics = await _clinicService.GetAllClinic();
                var existClinic = clinics.FirstOrDefault(x => x.Name == model.ClinicName);
                if (existClinic == null)
                {
                    var clinic = new ClinicMasterModel
                    {
                        Name = model.ClinicName,
                        Address = model.Address,
                        EmailId = model.Email,
                        Phone = model.PhoneNumber
                    };
                    var clinicdetails =  await _clinicService.AddClinic(clinic);
                    cid = clinicdetails.ClinicId;
                }
                else
                {
                    cid = existClinic.ClinicId;
                }
                var doctor = new DoctorMasterModel
                {
                    Name = model.DoctorName,
                    DoctorNo = model.PhoneNumber,
                    DoctorEmail = model.Email,
                    SkillId = model.SkillId,
                    ClinicId = cid,
                    InsDateTime = DateTime.Now,
                };
                await _doctorService.AddDoctor(doctor);

                return Ok(new { message = "Registration successful" });
            }
            return BadRequest(ModelState);
        }
    }
}
