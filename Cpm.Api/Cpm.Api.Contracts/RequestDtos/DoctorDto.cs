using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Contracts.RequestDtos
{
    public class DoctorDto
    {
        public string? Name { get; set; }
        public string? DoctorNo { get; set; }
        public DateOnly? DOB { get; set; }
        public string? DoctorEmail { get; set; }
        public int? SkillId { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public int? InsBy { get; set; }
        public DateTime? InsDateTime { get; set; }
        public int? UpdBy { get; set; }
        public DateTime? UpdDateTime { get; set; }
    }
}
