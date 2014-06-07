using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using ProstateBioBank.Data.Repsitories;
using ProstateBioBank.ServiceModels;
using ProstateBioBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstateBioBank
{
    public class PatientStoreTests
    {
        private Mock<IPatientRepository> _patientRepositoryMock;
        private PatientStore _sut;
        private static readonly IFixture _fixture;

        static PatientStoreTests()
        {
            _fixture = new Fixture();
            foreach (var behavior in _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList())
                _fixture.Behaviors.Remove(behavior);
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
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
                    _patients = _fixture.CreateMany<Domain.Patient>();
                    _patientRepositoryMock.Setup(r => r.GetPatients()).Returns(_patients.AsQueryable());
                }

                [Test]
                public async Task _then_service_model_mapped_patients_are_returned()
                {
                    var result = await _sut.GetPatientsAsync();
                }
            }
        }
    }
}
