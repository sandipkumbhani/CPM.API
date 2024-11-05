using Cpm.Api.Application.Interface;
using Cpm.Api.Domain.Interface;
using Cpm.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Provider
{
    public class LoginService : ILoginServices
    {
        private readonly IloginRepository _loginRepository;
        private readonly IPasswordHasher _passwordHasher;
        public LoginService(IloginRepository loginRepository, IPasswordHasher passwordHasher)
        {
            _loginRepository = loginRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<LoginModel?> GetAuthentication(string email, string password)
        {
            //var passwordHasher = _passwordHasher.HashPassword(password);
            var user = await _loginRepository.GetByEmailAsync(email);
            if (user == null || !_passwordHasher.VerifyPassword(user.Password, password))
            {
                return null;
            }
            return user;
        }

        public async Task<LoginModel?> GetByEmailAsync(string email)
        {
            return await _loginRepository.GetByEmailAsync(email);
        }

        public RoleMasterModel GetRoleByID(int id)
        {
            return _loginRepository.GetRoleById(id);
        }
    }
}
