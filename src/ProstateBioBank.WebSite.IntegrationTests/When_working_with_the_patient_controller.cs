using System.Data.Entity;
using NUnit.Framework;
using Ploeh.AutoFixture;
using ProstateBioBank.Controllers;
using ProstateBioBank.EntityFramework;
using ProstateBioBank.Models;
using StructureMap;
using System.Collections.Generic;
using System.Web.Mvc;
using Should;
using ProstateBioBank.ServiceModels;
using System.Threading.Tasks;

namespace ProstateBioBank.WebSite.IntegrationTests
{
    public class When_working_with_the_patient_controller
    {
        private static readonly IFixture Fixture = new Fixture();
        PatientController _sut;

        public When_working_with_the_patient_controller()
        {
            _sut = ObjectFactory.GetInstance<PatientController>();
        }

        public class _and_getting_the_index_view : When_working_with_the_patient_controller
        {
            [Test]
            public void a_patient_index_view_model_is_returned()
            {
                var view = _sut.Index() as ViewResult;
                view.Model.ShouldBeType<PatientIndexViewModel>();
            }
        }

        public class _and_adding_a_patient : When_working_with_the_patient_controller
        {
            [Test]
            public async Task _then_the_patient_is_stored_in_the_database()
            {
                var patient = Fixture.Create<Patient>();
                var entityFrameworkPatientRepository = ObjectFactory.GetInstance<EntityFrameworkPatientRepository>();
                await entityFrameworkPatientRepository.DeleteAsync(patient.Id);

                await _sut.CreateAsync(patient);

                var added = await entityFrameworkPatientRepository
                    .GetPatients().SingleOrDefaultAsync(p => p.Id == patient.Id);
                added.ShouldNotBeNull();
            }
        }
    }
}
