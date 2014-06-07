using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProstateBioBank.DependencyResolution;
using ProstateBioBank.WebSite.Bootstrapper;

namespace ProstateBioBank.WebSite.IntegrationTests
{
    [SetUpFixture]
    public class TestFixtureSetUp
    {
        [SetUp]
        public static void SetUp()
        {
            IoC.Initialize();
        }
    }
}
