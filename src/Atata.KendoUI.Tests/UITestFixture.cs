using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    [TestFixture]
    public abstract class UITestFixture
    {
        public const string BaseUrl = "http://localhost:56828/";

        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure().
                UseChrome().
                    WithArguments("start-maximized", "disable-infobars", "disable-extensions").
                UseBaseUrl(BaseUrl).
                UseCulture("en-US").
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                AddNLogLogging().
                AddScreenshotFileSaving().
                LogNUnitError().
                TakeScreenshotOnNUnitError().
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
