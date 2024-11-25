using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Contracts.RequestDtos
{
    public class PatientDiagnosisDto
    {
        public int? PatientId { get; set; }
        public DateTime? VisitedDateTime { get; set; }
        public string? Comments { get; set; } = null;
        public string? Report { get; set; } = null;
        public string? prescription { get; set; } = null;
        public string? FoodSuggestions { get; set; } = null;
        public bool IsQueue { get; set; } = true;
    }
}
