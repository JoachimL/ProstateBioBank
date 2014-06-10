using NUnit.Framework;
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
