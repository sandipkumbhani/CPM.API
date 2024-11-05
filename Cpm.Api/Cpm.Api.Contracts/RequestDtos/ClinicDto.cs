using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Contracts.RequestDtos
{
    public class ClinicDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? EmailId { get; set; }
        public string? Phone { get; set; }
        public int IsPasswordChange { get; set; } = 0;
        public int IsApprove { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public int? InsBy { get; set; }
        public DateTime? InsDateTime { get; set; }
        public int? UpdBy { get; set; }
        public DateTime? UpdDateTime { get; set; }
    }
}
