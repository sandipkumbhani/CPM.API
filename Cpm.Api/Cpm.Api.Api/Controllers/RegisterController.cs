using Cpm.Api.Application.Interface;
using Cpm.Api.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cpm.Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly IClinicService _clinicService;
        private readonly IDoctorService _doctorService;
        public RegisterController(IClinicService clinicService, IDoctorService doctorService)
        {
            _doctorService = doctorService;
            _clinicService = clinicService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var clinic = new ClinicMasterModel
                {
                    Name = model.ClinicName,
                    Address = model.Address,
                    EmailId = model.Email,
                    Phone = model.PhoneNumber
                };
                await _clinicService.AddClinic(clinic);

                var doctor = new DoctorMasterModel
                {
                    Name = model.DoctorName,
                    DoctorNo = model.PhoneNumber,
                    DoctorEmail = model.Email,
                    SkillId = model.SkillId,
                    InsDateTime = DateTime.Now
                };
                await _doctorService.AddDoctor(doctor);

                return Ok(new { message = "Registration successful" });
            }
            return BadRequest(ModelState);
        }
    }
}
