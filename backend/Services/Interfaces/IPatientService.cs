using backend.Models;

namespace backend.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(Guid id);

    }
}
