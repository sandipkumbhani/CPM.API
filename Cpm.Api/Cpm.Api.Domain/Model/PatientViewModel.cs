using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Domain.Model
{
    public class PatientViewModel
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string? Weight { get; set; } = null;
        public string? Height { get; set; } = null;
        public string? SmokingOrNicotine { get; set; } = null;
        public string? Physically_abled { get; set; } = null;
        public string? isDiabatice { get; set; } = null;
        public string? BP {  get; set; } = null;
        public int? ClinicId { get; set; }
        [ForeignKey("ClinicId")]
        public ClinicMasterModel? ClinicMaster { get; set; }

    }
}
