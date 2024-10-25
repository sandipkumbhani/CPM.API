using System.ComponentModel.DataAnnotations;

namespace Cpm.Api.Domain.Model
{
    public class RoleMasterModel
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
