using ProstateBioBank.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstateBioBank.Services
{
    public interface IPatientStore
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task AddPatientAsync(Patient patient);
        Task<Patient> GetPatientByIdAsync(string id);
    }
}
