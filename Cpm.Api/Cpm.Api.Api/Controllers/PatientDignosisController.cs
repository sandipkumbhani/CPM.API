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

    public class PatientDignosisController : ControllerBase
    {   
        private readonly IPatientDiagnosisService _patientDiagnosisService;
        private readonly IMapper _mapper;

        public PatientDignosisController(IPatientDiagnosisService patientDiagnosisService, IMapper mapper)
        {
            _patientDiagnosisService = patientDiagnosisService;
            _mapper = mapper;
        }
        [HttpGet("GetAllDignosis")]
        public async Task<ActionResult<IEnumerable<PatientDiagnosisViewModel>>> GetAll()
        {
            var result = await _patientDiagnosisService.GetAll();
            if (result == null)
            {
                NotFound("Patient Dignosis List unavilable");
            }
            return Ok(result);
        }
        [HttpPost("AddDiagnosis")]
        public async Task<ActionResult<PatientDiagnosisViewModel>> AddDiagnosis(PatientDiagnosisDto model)
        {
            var result = _mapper.Map<PatientDiagnosisViewModel>(model);
            await _patientDiagnosisService.Add(result);
            return Ok(result);
        }
        [HttpGet("GetDignosisById/{id}")]
        public async Task<ActionResult<PatientDiagnosisViewModel>> GetById(int id)
        {
            var result = await _patientDiagnosisService.GetByID(id);
            if (result == null || result.PatientId == 0)
            {
                return NotFound("Patient Dignosis not Found");
            }
            return Ok(result);
        }
        [HttpPut("UpdateDignosis/{id}")]
        public async Task<ActionResult> UpdateDiagnosis(int id, PatientDiagnosisDto model)
        {
            var result = _mapper.Map<PatientDiagnosisViewModel>(model);
            result.Id = id;
            await _patientDiagnosisService.Update(result);
            return Ok(result);
        }
        [HttpPut("DeleteDiagnosis/{id}")]
        public async Task<ActionResult> DeleteDignosis(int id)
        {
            await _patientDiagnosisService.Delete(id);
            return Ok();
        }
    }
}

