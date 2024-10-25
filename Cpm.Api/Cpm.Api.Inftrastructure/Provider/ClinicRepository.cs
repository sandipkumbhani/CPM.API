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
    public class ClinicRepository : IClinicRepository
    {
        private readonly AppDbContext _dbContext;
        public ClinicRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;   
        }
        public async Task<ClinicMasterModel> AddClinic(ClinicMasterModel model)
        {
            await _dbContext.Clinic_master.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteClinic(ClinicMasterModel model)
        {
            _dbContext.Clinic_master.Update(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClinicMasterModel>> GetAllClinic()
        {
            return await _dbContext.Clinic_master.Where(x=>x.IsActive == true).ToListAsync();
        }

        public async Task<ClinicMasterModel> GetByID(int id)
        {
            return await _dbContext.Clinic_master.Where(x=>x.ClinicId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateClinic(ClinicMasterModel model)
        {
            _dbContext.Clinic_master.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
