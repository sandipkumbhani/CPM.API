using Cpm.Api.Application.Interface;
using Cpm.Api.Domain.Interface;
using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Provider
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<SkillMasterModel> AddSkill(SkillMasterModel skillMasterModel)
        {
            return await _skillRepository.AddSkill(skillMasterModel);
        }

        public async Task<int> DeleteSkill(int skillId)
        {
            var result = await _skillRepository.GetById(skillId);
            if (result != null)
            {
                result.IsActive = false;
                await _skillRepository.EditSkill(result);
                return 1;
            }
            return 0;
        }

        public async Task EditSkill(SkillMasterModel skillMasterModel)
        {
             await _skillRepository.EditSkill(skillMasterModel);
        }

        public async Task<IEnumerable<SkillMasterModel>> GetAllSkill()
        {
            return await _skillRepository.GetAll();
        }

        public async Task<SkillMasterModel> GetBySkillId(int skillId)
        {
            return await _skillRepository.GetById(skillId);
        }
    }
}
