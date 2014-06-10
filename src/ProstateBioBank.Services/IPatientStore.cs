using ProstateBioBank.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProstateBioBank.Services
{
    public interface IPatientStore
    {
        IEnumerable<Patient> GetPatients();
        Task AddPatientAsync(Patient patientModel);
        Task<Patient> GetPatientByIdAsync(string id);
    }
}
