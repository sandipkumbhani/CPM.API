using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Domain.Model
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string? ClinicName { get; set; }
        public string? DoctorName { get; set; }
        public int SkillId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
