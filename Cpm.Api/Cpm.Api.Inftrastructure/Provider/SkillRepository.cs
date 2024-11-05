using Cpm.Api.Domain.Interface;
using Cpm.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cpm.Api.Inftrastructure.Provider
{
    public class SkillRepository : ISkillRepository
    {private readonly AppDbContext _dbContext;
        public SkillRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<SkillMasterModel> AddSkill(SkillMasterModel skillMasterModel)
        {
            await _dbContext.Skill_master.AddAsync(skillMasterModel);
            await _dbContext.SaveChangesAsync();
            return skillMasterModel;
        }

        public async Task DeleteSkill(SkillMasterModel skillMasterModel)
        {
             _dbContext.Skill_master.Update(skillMasterModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditSkill(SkillMasterModel skillMasterModel)
        {
            _dbContext.Skill_master.Update(skillMasterModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SkillMasterModel>> GetAll()
        {
            return await _dbContext.Skill_master.Where(x=>x.IsActive == true).ToListAsync();
        }

        public async Task<SkillMasterModel> GetById(int id)
        {
            return await _dbContext.Skill_master.FirstOrDefaultAsync(x=>x.SkillId == id);
        }
    }
}
