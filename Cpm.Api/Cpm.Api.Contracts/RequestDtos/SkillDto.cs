using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Contracts.RequestDtos
{
    public class SkillDto
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
