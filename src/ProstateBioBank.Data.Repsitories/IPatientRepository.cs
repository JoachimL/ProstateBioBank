using ProstateBioBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstateBioBank.Data.Repsitories
{
    public interface IPatientRepository
    {
        IQueryable<Patient> GetPatients();
    }
}
