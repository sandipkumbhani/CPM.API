using AutoMapper;
using Cpm.Api.Application.Interface;
using Cpm.Api.Contracts.RequestDtos;
using Cpm.Api.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cpm.Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillMasterController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;
        public SkillMasterController(ISkillService skillService,IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }
        [HttpGet("GetAllSkill")]
        public async Task<ActionResult<IEnumerable<SkillMasterModel>>> GetAll()
        {
            var result = await _skillService.GetAllSkill();
            if (result == null)
            {
                NotFound("No Record Found");
            }
            return Ok(result);
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<SkillMasterModel>> Get(int id)
        {
            var record = await _skillService.GetBySkillId(id);
            if (record == null || record.SkillId == 0)
            {
                NotFound("No Data Found");
            }
            return Ok(record);
        }
        [HttpPost("AddSkill")]
        public async Task<ActionResult<SkillMasterModel>> Add(SkillDto skillDto)
        {
            var result = _mapper.Map<SkillMasterModel>(skillDto);
            await _skillService.AddSkill(result);
            return Ok(result);
        }
        [HttpPut("UpdateSkil/{id}")]
        public async Task<ActionResult> Update(int id, SkillDto SkillDto)
        {
            var result = _mapper.Map<SkillMasterModel>(SkillDto);
            result.SkillId = id;
            await _skillService.EditSkill(result);
            return Ok(result);
        }
        [HttpPut("DeleteSkill/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _skillService.DeleteSkill(id);
            return Ok(result);
        }

    }
}
