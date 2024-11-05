using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Interface
{
    public interface ILoginServices
    {
        Task<LoginModel?> GetAuthentication(string email, string password);
        Task<LoginModel?> GetByEmailAsync(string email);
        RoleMasterModel GetRoleByID(int id);
    }
}
