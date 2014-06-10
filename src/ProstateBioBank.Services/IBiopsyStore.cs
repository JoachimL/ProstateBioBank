using ProstateBioBank.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProstateBioBank.Services
{
    public interface IBiopsyStore
    {
        Task<IEnumerable<Biopsy>> GetBiopsiesAsync();
        IEnumerable<Biopsy> GetBiopsies();
        Task AddAlequotAsync(Alequot alequot);
        Task<IEnumerable<Alequot>> GetAlequotsAsync();
        Task AddBiopsyAsync(Biopsy biopsy);
        Task<Alequot> GetAlequotByIdAsync(string id);
        Task<Biopsy> GetBiopsyByIdAsync(string id);
        Task DeleteBiopsyAsync(string id);
    }
}
