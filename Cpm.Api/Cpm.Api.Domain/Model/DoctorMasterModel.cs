using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cpm.Api.Domain.Model
{
    public class DoctorMasterModel
    {
        [Key] 
        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? DoctorNo { get; set; }
        public DateOnly? DOB { get; set; }
        public string? DoctorEmail { get; set; }
        public int? SkillId { get; set; } = 0;
        [ForeignKey("SkillId")]
        public SkillMasterModel? SkillMaster { get; set; }
        public int? ClinicId { get; set; } 
        [ForeignKey("ClinicId")]
        public ClinicMasterModel? ClinicMaster { get; set; }    
        public int? RoleId { get; set; } = 1;
        [ForeignKey("RoleId")]
        public RoleMasterModel? RoleMaster { get; set; }

        public bool IsActive { get; set; } = true;
        public int? InsBy { get; set; }
        public DateTime? InsDateTime { get; set; }
        public int? UpdBy { get; set; }
        public DateTime? UpdDateTime { get; set; }
    }
}
