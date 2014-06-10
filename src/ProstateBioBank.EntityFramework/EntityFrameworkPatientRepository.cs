using System;
using System.Linq;
using System.Threading.Tasks;
using ProstateBioBank.Data.Repositories;
using ProstateBioBank.Domain;

namespace ProstateBioBank.EntityFramework
{
    public class EntityFrameworkPatientRepository : EntityFrameworkRepository, IPatientRepository
    {
        public EntityFrameworkPatientRepository(Func<ProstateBioBankContext> getContext)
            : base(getContext)
        {
            
        }

        public IQueryable<Patient> GetPatients()
        {
            return Context.Patients;
        }

        public Task AddPatientAsync(Patient patient)
        {
            Context.Patients.Add(patient);
            return Context.SaveChangesAsync();
        }

        public Task DeleteAsync(string patientId)
        {
            var patient = Context.Patients.SingleOrDefault(p => p.Id == patientId);
            if (patient != null)
                Context.Patients.Remove(patient);
            return Context.SaveChangesAsync();
        }
    }
}
