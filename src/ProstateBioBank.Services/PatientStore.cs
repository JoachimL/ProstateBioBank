using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProstateBioBank.Data.Repositories;
using ProstateBioBank.ObjectExtensions;
using ProstateBioBank.ServiceModels;


namespace ProstateBioBank.Services
{
    public class PatientStore : IPatientStore
    {
        private readonly IPatientRepository _patientRepository;

        public PatientStore(IPatientRepository patientRepository)
        {
            _patientRepository = this.GetOrThrowArgumentNullException(patientRepository, "patientRepository");
        }

        public IEnumerable<ServiceModels.Patient> GetPatients()
        {
            return _patientRepository.GetPatients().Select(p => new Patient()
            {
                Id = p.Id,
                DateOfSurgery = p.DateOfSurgery,
                DAmicoScore = p.DAmicoScore,
                GleasonScore = p.GleasonScore,
                Psa = p.Psa,
                Tnm = p.Tnm,
                Ptnm = p.Ptnm,
                YearOfBirth = p.YearOfBirth
            });
        }

        public Task AddPatientAsync(Patient patientModel)
        {
            return _patientRepository.AddPatientAsync(new Domain.Patient()
            {
                Id = patientModel.Id,
                DAmicoScore = patientModel.DAmicoScore,
                GleasonScore = patientModel.GleasonScore,
                DateOfSurgery = patientModel.DateOfSurgery,
                Psa = patientModel.Psa,
                Tnm = patientModel.Tnm,
                YearOfBirth = patientModel.YearOfBirth,
                Ptnm = patientModel.Ptnm
            });
        }

        public Task<ServiceModels.Patient> GetPatientByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
