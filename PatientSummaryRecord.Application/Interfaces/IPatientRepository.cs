using PatientSummaryRecord.Domain.Entities;

namespace PatientSummaryRecord.Application.Interfaces
{
    public interface IPatientRepository
    {
        Patient GetPatientById(int id);
    }
}
