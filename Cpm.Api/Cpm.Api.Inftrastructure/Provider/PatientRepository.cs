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
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _dbContext;

        public PatientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PatientViewModel> AddPatient(PatientViewModel model)
        {
            await _dbContext.Patient.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task DeletePatient(PatientViewModel model)
        {
                _dbContext.Patient.Update(model);
                await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientViewModel>> GetAll()
        {
            return await _dbContext.Patient.ToListAsync();  
        }

        public async Task<PatientViewModel> GetByID(int id)
        {
            return await _dbContext.Patient.Where(x => x.PatientId == id).FirstOrDefaultAsync();
        }
        public async Task UpdatePatient(PatientViewModel model)
        {
            _dbContext.Patient.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
