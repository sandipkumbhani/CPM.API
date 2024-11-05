using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Application.Interface
{
    public interface IPasswordHasher 
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashPassword, string providePassword);
    }
}
