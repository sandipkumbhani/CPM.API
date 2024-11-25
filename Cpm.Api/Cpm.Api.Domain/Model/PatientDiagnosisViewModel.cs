using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Domain.Model
{
    public class PatientDiagnosisViewModel
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public PatientViewModel? Patient { get; set; }
        public DateTime? VisitedDateTime { get; set; }
        public string? Comments { get; set; } = null;
        public string? Report { get; set; } = null;
        public string? prescription { get; set; } = null;
        public string? FoodSuggestions { get; set;} = null;
        public bool IsQueue { get; set; } = true;
    }
}
