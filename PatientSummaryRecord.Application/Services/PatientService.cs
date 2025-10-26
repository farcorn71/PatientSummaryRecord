using PatientSummaryRecord.Application.Exceptions;
using PatientSummaryRecord.Application.Interfaces;
using PatientSummaryRecord.Domain.Entities;

namespace PatientSummaryRecord.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public Patient GetPatientSummary(int id)
        {
            var patient = _repository.GetPatientById(id);
            if (patient == null)
                throw new PatientNotFoundException(id);

            return patient;
        }
    }
}
