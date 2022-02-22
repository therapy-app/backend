using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _context.Patient.ToListAsync();
        }

        public async Task<Patient?> GetPatient(Guid id)
        {
            return await _context.Patient.FindAsync(id);
        }
    }
}
