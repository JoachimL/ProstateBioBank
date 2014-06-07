using ProstateBioBank.Services;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstateBioBank.WebSite.Bootstrapper
{
    public class ProstateBioBankStructureMapRegistry : Registry
    {
        public ProstateBioBankStructureMapRegistry()
        {
            For<IPatientStore>().Singleton().Use<PatientStore>();
        }
    }
}
