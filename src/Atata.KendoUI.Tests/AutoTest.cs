using System.Configuration;
using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    [TestFixture]
    public abstract class AutoTest
    {
        [SetUp]
        public void SetUp()
        {
            string baseUrl = ConfigurationManager.AppSettings["TestAppUrl"];

            AtataContext.Configure().
                UseChrome().
                    WithArguments("disable-extensions", "no-sandbox", "start-maximized").
                UseBaseUrl(baseUrl).
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                    WithMinLevel(LogLevel.Info).
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
