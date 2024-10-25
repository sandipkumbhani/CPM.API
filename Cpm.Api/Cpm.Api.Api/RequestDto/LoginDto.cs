using Cpm.Api.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpm.Api.Api.RequestDto
{
    public class LoginDto
    {
        public int UserId { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
