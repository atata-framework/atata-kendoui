using System;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    internal static class IUIComponentExtensions
    {
        internal static void WaitForCssTransitionEnd<TOwner>(this IUIComponent<TOwner> component, string transitionName, RetryOptions waitingOptions)
            where TOwner : PageObject<TOwner>
        {
            if (waitingOptions?.Timeout > TimeSpan.Zero)
            {
                AtataContext.Current.Log.Start($"Wait for {component.ComponentFullName} \"{transitionName}\" CSS transition completion", LogLevel.Trace);

                component.Scope.Try().Until(IsNoCssTransition, waitingOptions);

                AtataContext.Current.Log.EndSection();
            }
        }

        private static bool IsNoCssTransition(IWebElement element)
        {
            string transitionDuration = element.GetCssValue("transitionDuration");

            return transitionDuration == null
                || !decimal.TryParse(transitionDuration.TrimEnd('m', 's'), out decimal transitionTime)
                || transitionTime == 0;
        }
    }
}
