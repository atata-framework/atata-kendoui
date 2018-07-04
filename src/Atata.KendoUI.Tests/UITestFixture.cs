using System.Configuration;
using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    [TestFixture]
    public abstract class UITestFixture
    {
        [SetUp]
        public void SetUp()
        {
            string baseUrl = ConfigurationManager.AppSettings["TestAppUrl"];

            AtataContext.Configure().
                UseChrome().
                    WithArguments("start-maximized", "disable-infobars", "disable-extensions").
                UseBaseUrl(baseUrl).
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                LogNUnitError().
                Build();

            OnSetUp();
        }

        protected virtual void OnSetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current.CleanUp();
        }
    }
}
