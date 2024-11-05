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
    public class LoginRepository : IloginRepository
    {
        private readonly AppDbContext _dbContext;
        public LoginRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<LoginModel?> GetAuthentication(string email, string password)
        {
            return await _dbContext.Login_Model.Where(x=>x.EmailId == email && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<LoginModel?> GetByEmailAsync(string email)
        {
            return await _dbContext.Login_Model.Where(x=>x.EmailId == email).FirstOrDefaultAsync();
        }

        public RoleMasterModel GetRoleById(int id)
        {
           return _dbContext.Role_master.Where(x=>x.RoleId==id).FirstOrDefault();
        }
    }
}
