 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cpm.Api.Domain.Model
{
    public class LoginModel
    {
        [Key]
        public int LoginId { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public DoctorMasterModel? DoctorMaster { get; set; }

        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleMasterModel? RoleMaster { get; set; }

    }
}
