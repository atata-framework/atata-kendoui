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
                    WithLocalDriverPath().
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

        protected static SnippetPage GoToSnippetPage(KendoLibrary library)
        {
            string componentName = TestContext.CurrentContext.Test.MethodName;
            string prefixToRemove = "Kendo";

            if (componentName.StartsWith(prefixToRemove))
                componentName = componentName.Remove(0, prefixToRemove.Length);

            return GoToSnippetPage(library, componentName);
        }

        protected static SnippetPage GoToSnippetPage(KendoLibrary library, string componentName)
        {
            string url = ResolveSnippetPageUrl(library, componentName);
            return GoToSnippetPage(url);
        }

        private static string ResolveSnippetPageUrl(KendoLibrary library, string componentName)
        {
            switch (library)
            {
                case KendoLibrary.JQuery:
                    return componentName.ToLowerInvariant();
                case KendoLibrary.Angular:
                    return $"https://www.telerik.com/kendo-angular-ui/components/{componentName.ToLowerInvariant()}";
                case KendoLibrary.AspNetMvc:
                    return $"https://demos.telerik.com/aspnet-mvc/{componentName.ToLowerInvariant()}";
                case KendoLibrary.AspNetCore:
                    return $"https://demos.telerik.com/aspnet-core/{componentName.ToLowerInvariant()}";
                default:
                    return $"https://atata-kendoui-{library.ToString().ToLowerInvariant()}-{componentName.ToLowerInvariant()}.stackblitz.io";
            }
        }

        protected static SnippetPage GoToSnippetPage(string url)
        {
            return Go.To<SnippetPage>(url: url);
        }
    }
}
