using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProstateBioBank.ServiceModels;

namespace ProstateBioBank.Models
{
    public class PatientIndexViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
    }
}