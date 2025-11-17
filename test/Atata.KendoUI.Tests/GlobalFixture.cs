using System.Net.NetworkInformation;
using Atata.Cli;
using Atata.WebDriverSetup;

[assembly: SetCulture("en-US")]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Atata.KendoUI.Tests;

[SetUpFixture]
public class GlobalFixture : AtataGlobalFixture
{
    private const int TestAppPort = 56828;

    private static readonly string s_baseUrl = $"http://localhost:{TestAppPort}/";

    private CliCommand? _dotnetRunCommand;

    protected override void OnBeforeGlobalSetup() =>
        ThreadPool.SetMinThreads(Environment.ProcessorCount * 4, Environment.ProcessorCount);

    protected override void ConfigureAtataContextGlobalProperties(AtataContextGlobalProperties globalProperties) =>
        globalProperties.UseRootNamespaceOf<GlobalFixture>();

    protected override void ConfigureAtataContextBaseConfiguration(AtataContextBuilder builder)
    {
        builder.Sessions.AddWebDriver(x => x
            .UseStartScopes(AtataContextScopes.Test)
            .UseChrome(x => x
                .WithArguments(GetChromeArguments()))
            .UseBaseUrl(s_baseUrl));

        builder.LogConsumers.AddNLogFile();
    }

    private static IEnumerable<string> GetChromeArguments()
    {
        yield return "start-maximized";
        yield return "disable-search-engine-choice-screen";

        bool headless = TestContext.Parameters.Get("headless", false);

        if (headless)
            yield return "headless=new";
    }

    [OneTimeSetUp]
    public async Task GlobalSetUpAsync() =>
        await Task.WhenAll(
            DriverSetup.AutoSetUpAsync(BrowserNames.Chrome),
            Task.Run(SetUpTestApp));

    private static bool IsTestAppRunning() =>
        IPGlobalProperties.GetIPGlobalProperties()
            .GetActiveTcpListeners()
            .Any(x => x.Port == TestAppPort);

    private void SetUpTestApp()
    {
        if (!IsTestAppRunning())
            StartTestApp();
    }

    private void StartTestApp()
    {
        string testAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Atata.KendoUI.TestApp");

        ProgramCli dotnetCli = new ProgramCli("dotnet", useCommandShell: true)
            .WithWorkingDirectory(testAppPath);

        _dotnetRunCommand = dotnetCli.Start("run");

        SafeWait<GlobalFixture> testAppWait = new(this)
        {
            Timeout = TimeSpan.FromSeconds(40),
            PollingInterval = TimeSpan.FromSeconds(0.2)
        };

        testAppWait.Until(x => IsTestAppRunning());
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        if (_dotnetRunCommand is not null)
        {
            _dotnetRunCommand.Kill(true);
            _dotnetRunCommand.Dispose();
        }
    }
}
