using NUnit.Framework;
using ProstateBioBank.Controllers;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Should;
using ProstateBioBank.ServiceModels;

namespace ProstateBioBank.WebSite.IntegrationTests
{
    public class When_working_with_the_patient_controller
    {
        PatientController _sut;

        public When_working_with_the_patient_controller()
        {
            _sut = ObjectFactory.GetInstance<PatientController>();
        }

        public class _and_getting_the_index_view : When_working_with_the_patient_controller
        {
            [Test]
            public async Task a_patient_index_view_model_is_returned()
            {
                var view = await _sut.Index() as ViewResult;
                view.Model.ShouldBeType<IEnumerable<Patient>>();
            }
        }
    }
}
