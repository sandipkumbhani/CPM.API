using System.ComponentModel.DataAnnotations;

namespace Cpm.Api.Domain.Model
{
    public class SkillMasterModel
    {
        [Key] 
        public int SkillId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; } = true;
        public int? InsBy { get; set; }
        public DateTime? InsDateTime { get; set; }
        public int? UpdBy { get; set; }
        public DateTime? UpdDateTime { get; set; }
    }
}
