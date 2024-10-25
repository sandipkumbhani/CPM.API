using AutoMapper;
using Cpm.Api.Application.Interface;
using Cpm.Api.Application.Provider;
using Cpm.Api.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cpm.Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;
        private readonly IMapper _mapper;
        public ClinicController(IClinicService clinicService,IMapper mapper)
        {
            _clinicService = clinicService;
            _mapper = mapper;
        }
     
        [HttpGet("GetAllClinic")]
        public async Task<ActionResult<IEnumerable<ClinicMasterModel>>> GetAll()
        {
            var result = await _clinicService.GetAllClinic();
            if(result == null)
            {
                NotFound("ClinicList unavailable");
            }
            return Ok(result);
        }
        [HttpPost("AddClinic")]
        public async Task<ActionResult<ClinicMasterModel>> AddClinic(ClinicMasterModel model)
        {
            var result = _mapper.Map<ClinicMasterModel>(model);
            await _clinicService.AddClinic(result);
            return Ok(result);
        }
        [HttpGet("GetClinicById/{id}")]
        public async Task<ActionResult<ClinicMasterModel>> GetById(int id)
        {
            var result = await _clinicService.GetByID(id);
            if (result == null || result.ClinicId == 0)
            {
                return NotFound("Doctor not Found");
            }
            return Ok(result);
        }
        [HttpPut("UpdateClinic/{id}")]
        public async Task<ActionResult> UpdateClinic(int id, ClinicMasterModel model)
        {
            var result = _mapper.Map<ClinicMasterModel>(model);
            result.ClinicId = id;
            await _clinicService.UpdateClinic(result);
            return Ok(result);
        }

        [HttpPut("DeleteClinic/{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await _clinicService.DeleteClinic(id);
            return Ok();
        }
    }
}
