using AutoMapper;
using Cpm.Api.Application.Interface;
using Cpm.Api.Application.Provider;
using Cpm.Api.Contracts.RequestDtos;
using Cpm.Api.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cpm.Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    //[Authorize(Roles ="Admin")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }
        [HttpGet("GetAllDoctor")]
        public async Task<ActionResult<IEnumerable<DoctorMasterModel>>> GetAll()
        {
            var result = await _doctorService.GetAll();
            if(result == null)
            {
                NotFound("DoctorList unavilable");
            }
            return Ok(result);
        }
        [HttpPost("AddDoctor")]
        public async Task<ActionResult<DoctorMasterModel>> AddDoctor(DoctorDto model)
        {
            var result = _mapper.Map<DoctorMasterModel>(model);
            await _doctorService.AddDoctor(result);
            return Ok(result);
        }
        [HttpGet("GetDoctorById/{id}")]
        public async Task<ActionResult<DoctorMasterModel>> GetById(int id)
        {
            var result = await _doctorService.GetByID(id);
            if (result == null || result.DoctorId == 0)
            {
                return NotFound("Doctor not Found");
            }
            return Ok(result);
        }
        [HttpPut("UpdateDoctor/{id}")]
        public async Task<ActionResult> UpdateDoctor(int id, DoctorDto model)
        {
            var result = _mapper.Map<DoctorMasterModel>(model);
            result.DoctorId = id;
            await _doctorService.UpdateDoctor(result);
            return Ok(result);
        }

        [HttpPut("DeleteDoctor/{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteDoctor(id);
            return Ok();
        }
    }
}
