using System;
using System.Collections.Generic;
using System.Text;

namespace PatientSummaryRecord.Application.DTOs
{
    public class PatientDto
    {
        public string Name { get; set; }
        public string NHSNumber { get; set; }
        public string GPPractice { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
