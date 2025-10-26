using PatientSummaryRecord.Domain.Entities;

namespace PatientSummaryRecord.Application.Interfaces
{
    public interface IPatientService
    {
        Patient GetPatientSummary(int id);
    }
}
