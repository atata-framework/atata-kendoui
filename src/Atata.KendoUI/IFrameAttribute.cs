using OpenQA.Selenium;

namespace Atata
{

    public class IFrameAttribute : TriggerAttribute, IPropertySettings
    {
        private readonly string xPath;

        public static System.Collections.Generic.Queue<string> LastFrameXPath { get; }

        public PropertyBag Properties { get; } = new PropertyBag();

        static IFrameAttribute()
        {
            LastFrameXPath = new System.Collections.Generic.Queue<string>();
            LastFrameXPath.Enqueue(string.Empty);
        }

        public IFrameAttribute(string xPath = "")
            : base(TriggerEvents.BeforeGetOrSet | TriggerEvents.AfterGetOrSet)
        {
            this.xPath = xPath;
        }

        protected override void Execute<TOwner>(TriggerContext<TOwner> context)
        {
            if (context.Event.HasFlag(TriggerEvents.BeforeGet) || context.Event.HasFlag(TriggerEvents.BeforeSet))
            {
                SwitchToFrame(context.Driver, xPath);
                context.Log.Info($"Switched to frame '{xPath}'");
            }
            else if (context.Event.HasFlag(TriggerEvents.AfterGet) || context.Event.HasFlag(TriggerEvents.AfterSet))
            {
                var lastXPath = LastFrameXPath.Dequeue();
                SwitchToFrame(context.Driver, lastXPath);
                context.Log.Info($"Switched to frame '{lastXPath}'");
            }
        }

        private void SwitchToFrame(OpenQA.Selenium.Remote.RemoteWebDriver driver, string xpath)
        {
            if (string.IsNullOrEmpty(xpath))
            {
                driver.SwitchTo().DefaultContent();
            }
            else
            {
                IWebElement iframe = driver.Get(By.XPath(xpath));
                driver.SwitchTo().Frame(iframe);
            }

            LastFrameXPath.Enqueue(xPath);
        }
    }
}
