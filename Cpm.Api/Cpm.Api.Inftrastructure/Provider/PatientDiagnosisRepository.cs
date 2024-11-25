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
    public class PatientDiagnosisRepository : IPatientDiagnosisRepository
    {
        private readonly AppDbContext _dbContext;

        public PatientDiagnosisRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PatientDiagnosisViewModel> Add(PatientDiagnosisViewModel model)
        {
            await _dbContext.Patient_Diagnosis.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task Delete(PatientDiagnosisViewModel model)
        {
            _dbContext.Patient_Diagnosis.Update(model);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<PatientDiagnosisViewModel>> GetAll()
        {
            return await _dbContext.Patient_Diagnosis.Include(x=>x.Patient).ToListAsync();
        }

        public async Task<PatientDiagnosisViewModel> GetByID(int id)
        {
            return await _dbContext.Patient_Diagnosis.Where(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task Update(PatientDiagnosisViewModel model)
        {
            _dbContext.Patient_Diagnosis.Update(model);
            await _dbContext.SaveChangesAsync();

        }

    }
}
