using Cpm.Api.Domain.Interface;
using Cpm.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Inftrastructure.Provider
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _dbContext;
        public DoctorRepository(AppDbContext appDbContext)
        {
             _dbContext = appDbContext;
        }
        public async Task<DoctorMasterModel> AddDoctor(DoctorMasterModel model)
        {
           await _dbContext.Doctor_master.AddAsync(model);
           await _dbContext.SaveChangesAsync();
           return model;
        }
        public async Task DeleteDoctor(DoctorMasterModel model)
        {
            _dbContext.Doctor_master.Update(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoctorMasterModel>> GetAll()
        {
           return await _dbContext.Doctor_master.Where(x=>x.IsActive == true).Include(x=>x.ClinicMaster).Include(x=>x.SkillMaster).Include(x=>x.RoleMaster).ToListAsync();
        }

        public async Task<DoctorMasterModel> GetByID(int id)
        {
            return await _dbContext.Doctor_master.Where(x=>x.DoctorId == id).Include(x=>x.ClinicMaster).FirstOrDefaultAsync();
        }

        public async Task UpdateDoctor(DoctorMasterModel model)
        {
            _dbContext.Doctor_master.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
