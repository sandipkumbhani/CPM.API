using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Interface
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillMasterModel>> GetAllSkill();
        Task<SkillMasterModel> GetBySkillId(int skillId);
        Task<SkillMasterModel> AddSkill(SkillMasterModel skillMasterModel);
        Task EditSkill(SkillMasterModel skillMasterModel);
        Task<int> DeleteSkill(int skillId);
    }
}
