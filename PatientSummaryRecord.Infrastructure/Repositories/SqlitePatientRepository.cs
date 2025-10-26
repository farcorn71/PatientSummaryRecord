using PatientSummaryRecord.Application.Interfaces;
using PatientSummaryRecord.Domain.Entities;
using PatientSummaryRecord.Infrastructure.Data;

namespace PatientSummaryRecord.Infrastructure.Repositories
{
    public class SqlitePatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _context;

        public SqlitePatientRepository(PatientDbContext context)
        {
            _context = context;
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.Find(id);
        }
    }
}
