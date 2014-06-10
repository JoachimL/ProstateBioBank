using ProstateBioBank.Data.Repositories;
using ProstateBioBank.EntityFramework;
using ProstateBioBank.Services;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace ProstateBioBank.WebSite.Bootstrapper
{
    public class ProstateBioBankStructureMapRegistry : Registry
    {
        public ProstateBioBankStructureMapRegistry()
        {
            For<IPatientStore>().Singleton().Use<PatientStore>();
            For<IPatientRepository>().Singleton().Use<EntityFrameworkPatientRepository>();
            For<ProstateBioBankContext>().HybridHttpOrThreadLocalScoped();
        }
    }
}
