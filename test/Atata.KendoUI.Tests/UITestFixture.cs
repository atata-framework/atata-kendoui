﻿using System.Reflection;
using NUnit.Framework.Internal;

namespace Atata.KendoUI.Tests;

[TestFixture]
[Parallelizable]
public abstract class UITestFixture
{
    public const int TestAppPort = 56828;

    public static string BaseUrl { get; } = $"http://localhost:{TestAppPort}/";

    [SetUp]
    public void SetUp()
    {
        AtataContext.Configure()
            .UseChrome()
                .WithArguments(GetChromeArguments())
            .UseBaseUrl(BaseUrl)
            .UseCulture("en-US")
            .UseAllNUnitFeatures()
            .LogConsumers.AddNLogFile()
            .ScreenshotConsumers.AddFile()
            .Build();

        OnSetUp();
    }

    private static IEnumerable<string> GetChromeArguments()
    {
        yield return "start-maximized";
        yield return "disable-extensions";

        bool headless = TestContext.Parameters.Get("headless", false);

        if (headless)
            yield return "headless";
    }

    protected virtual void OnSetUp()
    {
    }

    [TearDown]
    public void TearDown() =>
        AtataContext.Current?.Dispose();

    protected static TPage GoToTestPage<TPage>(string library)
        where TPage : Page<TPage>
    {
        string kendoUIVersion = library.Split('/')[1];
        string pageUrl = typeof(TPage).GetCustomAttribute<UrlAttribute>().Value;
        return Go.To<TPage>(url: $"{pageUrl}?v={kendoUIVersion}");
    }

    protected static SnippetPage GoToSnippetPage(string library)
    {
        string componentName = RetrieveComponentNameFromTestName();

        return GoToSnippetPage(library, componentName);
    }

    protected static SnippetPage GoToSnippetPage(string library, string componentName)
    {
        string url = ResolveSnippetPageUrl(library, componentName);
        return GoToSnippetPageByUrl(url);
    }

    private static SnippetPage GoToSnippetPageByUrl(string url)
    {
        var page = Go.To<SnippetPage>(url: url);

        if (url.Contains(".stackblitz.io"))
            page.WaitAndClickRunButton();
        else if (url.Contains("demos.telerik.com"))
            page.WaitAndClickAcceptAndCloseButton();

        return page;
    }

    protected static SnippetPage GoToAngularDemoPage(string componentName)
    {
        string url = $"https://www.telerik.com/kendo-angular-ui/components/{componentName.ToLowerInvariant()}";
        return GoToSnippetPageByUrl(url);
    }

    private static string RetrieveComponentNameFromTestName()
    {
        string componentName = TestContext.CurrentContext.Test.MethodName;

        if (componentName == "Interact")
        {
            componentName = TestContext.CurrentContext.Test.ClassName[..^5];
            componentName = componentName[(componentName.LastIndexOf('.') + 1)..];
        }

        string[] prefixOptionsToRemove =
        [
            "VueKendo",
            "NgKendo",
            "ReactKendo",
            "Kendo"
        ];

        string prefixToRemove = prefixOptionsToRemove.FirstOrDefault(prefix => componentName.StartsWith(prefix, StringComparison.Ordinal));

        return prefixToRemove != null
            ? componentName.Remove(0, prefixToRemove.Length)
            : componentName;
    }

    private static string ResolveSnippetPageUrl(string library, string componentName) =>
        library switch
        {
            var x when x.StartsWith(KendoLibraries.JQuery, StringComparison.OrdinalIgnoreCase) => $"{componentName.ToLowerInvariant()}?v={library.Split('/')[1]}",
            KendoLibraries.AspNetMvc => $"https://demos.telerik.com/aspnet-mvc/{componentName.ToLowerInvariant()}",
            KendoLibraries.AspNetCore => $"https://demos.telerik.com/aspnet-core/{componentName.ToLowerInvariant()}",
            _ => $"https://atata-kendoui-{library.ToLowerInvariant()}-{componentName.ToLowerInvariant()}.stackblitz.io",
        };
}
