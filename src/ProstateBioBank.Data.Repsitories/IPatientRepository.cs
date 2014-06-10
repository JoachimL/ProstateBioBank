using System.Linq;
using System.Threading.Tasks;
using ProstateBioBank.Domain;

namespace ProstateBioBank.Data.Repositories
{
    public interface IPatientRepository
    {
        IQueryable<Patient> GetPatients();
        Task AddPatientAsync(Patient patient);
    }
}
