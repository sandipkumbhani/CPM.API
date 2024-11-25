using AutoMapper;
using Cpm.Api.Application.Interface;
using Cpm.Api.Application.Provider;
using Cpm.Api.Contracts.RequestDtos;
using Cpm.Api.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cpm.Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        public PatientController(IMapper mapper, IPatientService patientService)
        {
            _mapper = mapper;
            _patientService = patientService;
        }
        [HttpGet("GetAllPatient")]
        public async Task<ActionResult<IEnumerable<PatientViewModel>>> GetAll()
        {
            var result = await _patientService.GetAllPatient();
            if (result == null)
            {
                NotFound("PatientList unavilable");
            }
            return Ok(result);
        }
        [HttpPost("AddPatient")]
        public async Task<ActionResult<PatientViewModel>> AddPatient(PatientDto model)
        {
            var result = _mapper.Map<PatientViewModel>(model);
            await _patientService.AddPatient(result);
            return Ok(result);
        }
        [HttpGet("GetPatientById/{id}")]
        public async Task<ActionResult<PatientViewModel>> GetById(int id)
        {
            var result = await _patientService.GetByID(id);
            if (result == null || result.PatientId == 0)
            {
                return NotFound("Patient not Found");
            }
            return Ok(result);
        }
        [HttpPut("UpdatePatient/{id}")]
        public async Task<ActionResult> UpdatePatient(int id, PatientDto model)
        {
            var result = _mapper.Map<PatientViewModel>(model);
            result.PatientId = id;
            await _patientService.UpdatePatient(result);
            return Ok(result);
        }
        [HttpPut("DeletePatient/{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            await _patientService.DeletePatient(id);
            return Ok();
        }
    }
}
