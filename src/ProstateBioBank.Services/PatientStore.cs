using ProstateBioBank.Data.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProstateBioBank.ObjectExtensions;
using ProstateBioBank.ServiceModels;
using System.Data.Entity;

namespace ProstateBioBank.Services
{
    public class PatientStore : IPatientStore
    {
        private readonly IPatientRepository _patientRepository;

        public PatientStore(IPatientRepository patientRepository)
        {
            _patientRepository = this.GetOrThrowArgumentNullException(patientRepository, "patientRepository");
        }

        public async Task<IEnumerable<ServiceModels.Patient>> GetPatientsAsync()
        {
            var patients = _patientRepository.GetPatients().Select(p => new Patient());
            return await patients.ToListAsync();
        }

        public Task AddPatientAsync(ServiceModels.Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceModels.Patient> GetPatientByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
