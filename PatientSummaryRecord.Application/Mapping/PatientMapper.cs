using PatientSummaryRecord.Application.DTOs;
using PatientSummaryRecord.Domain.Entities;

namespace PatientSummaryRecord.Application.Mapping
{
    

    namespace PatientSummaryRecord.Application.Mapping
    {
        //TODO: Use AutoMapper for more complex mappings in the future
        public static class PatientMapper
        {
            public static PatientDto MapToDto(Patient patient)
            {
                return new PatientDto
                {
                    Name = patient.Name,
                    NHSNumber = patient.NHSNumber,
                    GPPractice = patient.GPPractice,
                    DateOfBirth = patient.DateOfBirth
                };
            }
        }
    }
}
