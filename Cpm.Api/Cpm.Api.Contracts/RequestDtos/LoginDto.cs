using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Contracts.RequestDtos
{
    public class LoginDto
    {
        public int DoctorId { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
