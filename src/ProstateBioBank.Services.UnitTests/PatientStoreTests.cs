using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using ProstateBioBank.Data.Repositories;
using ProstateBioBank.Domain;
using Should;

namespace ProstateBioBank.Services
{
    public class PatientStoreTests
    {
        private Mock<IPatientRepository> _patientRepositoryMock;
        private PatientStore _sut;
        private static readonly IFixture Fixture;

        static PatientStoreTests()
        {
            Fixture = new Fixture();
            foreach (var behavior in Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList())
                Fixture.Behaviors.Remove(behavior);
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [SetUp]
        public virtual void SetUp()
        {
            _patientRepositoryMock = new Mock<IPatientRepository>();
            _sut = new PatientStore(_patientRepositoryMock.Object);
        }

        public class When_getting_patients : PatientStoreTests
        {
            public class _and_the_repository_returns_data : When_getting_patients
            {
                IEnumerable<Domain.Patient> _patients;

                public override void SetUp()
                {
                    base.SetUp();
                    _patients = Fixture.CreateMany<Domain.Patient>();

                    _patientRepositoryMock.Setup(r => r.GetPatients()).Returns(_patients.AsQueryable());
                }

                [Test]
                public void _then_service_models_are_returned()
                {
                    var result = _sut.GetPatients();
                    result.ShouldNotBeNull();
                }

                [Test]
                public void _then_the_service_models_are_projections_of_the_patients()
                {
                    var models = _sut.GetPatients();
                    for (var ii = 0; ii < _patients.Count(); ii ++)
                        ModelShouldBeProjectionOfPatient(models.ElementAt(ii), _patients.ElementAt(ii));
                }

                private void ModelShouldBeProjectionOfPatient(ServiceModels.Patient model, Patient patient)
                {
                    model.Id.ShouldEqual(patient.Id);
                    model.DateOfSurgery.ShouldEqual(patient.DateOfSurgery);
                    model.DAmicoScore.ShouldEqual((patient.DAmicoScore));
                    model.GleasonScore.ShouldEqual(patient.GleasonScore);
                    model.Psa.ShouldEqual(patient.Psa);
                    model.Ptnm.ShouldEqual(patient.Ptnm);
                    model.Tnm.ShouldEqual(patient.Tnm);
                    model.YearOfBirth.ShouldEqual(patient.YearOfBirth);
                }
            }
        }

        public class When_adding_a_patient : PatientStoreTests
        {
            public class _with_valid_data: When_adding_a_patient
            {
                [Test]
                public async Task _then_a_valid_domain_object_is_stored_in_the_repository()
                {
                    var patient = Fixture.Create<ServiceModels.Patient>();

                    await _sut.AddPatientAsync(patient);

                    _patientRepositoryMock.Verify(
                        r=>r.AddPatientAsync(It.Is<Patient>(
                            p=>p.Id == patient.Id
                            && p.DAmicoScore == patient.DAmicoScore
                            && p.DateOfSurgery == patient.DateOfSurgery
                            && p.GleasonScore == patient.GleasonScore
                            && p.Psa == patient.Psa
                            && p.Ptnm == patient.Ptnm
                            && p.Tnm == patient.Tnm
                            && p.YearOfBirth == patient.YearOfBirth)));
                }
            }
        }
    }
}
