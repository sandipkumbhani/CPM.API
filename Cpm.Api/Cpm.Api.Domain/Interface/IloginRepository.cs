using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Domain.Interface
{
    public interface IloginRepository
    {
        Task<LoginModel?> GetAuthentication(string email, string password);
        Task<LoginModel?> GetByEmailAsync(string email);
        RoleMasterModel GetRoleById(int id);
    }
}
