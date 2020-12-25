using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        private Process coreRunProcess;

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            try
            {
                PingTestApp();
            }
            catch
            {
                RunTestApp();
            }
        }

        private static WebResponse PingTestApp() =>
            WebRequest.CreateHttp(UITestFixture.BaseUrl).GetResponse();

        private void RunTestApp()
        {
            coreRunProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c dotnet run",
                    WorkingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Atata.KendoUI.TestApp")
                }
            };

            coreRunProcess.Start();

            Thread.Sleep(5000);

            var testAppWait = new SafeWait<SetUpFixture>(this)
            {
                Timeout = TimeSpan.FromSeconds(40),
                PollingInterval = TimeSpan.FromSeconds(1)
            };

            testAppWait.IgnoreExceptionTypes(typeof(WebException));

            testAppWait.Until(x => PingTestApp());
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            if (coreRunProcess != null)
            {
                coreRunProcess.Kill(true);
                coreRunProcess.Dispose();
            }
        }
    }
}
