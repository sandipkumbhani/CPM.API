using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Domain.Interface
{
    public interface ISkillRepository
    {
        Task<IEnumerable<SkillMasterModel>> GetAll();
        Task<SkillMasterModel> GetById(int id);
        Task<SkillMasterModel> AddSkill(SkillMasterModel skillMasterModel);
        Task EditSkill(SkillMasterModel skillMasterModel);
        Task DeleteSkill(SkillMasterModel skillMasterModel);
    }
}
