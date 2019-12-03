using System;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    internal static class IUIComponentExtensions
    {
        internal static TOwner WaitForCssTransitionEnd<TOwner>(this IUIComponent<TOwner> component, string transitionName, RetryOptions waitingOptions, SearchOptions searchOptions = null)
            where TOwner : PageObject<TOwner>
        {
            if (waitingOptions?.Timeout > TimeSpan.Zero)
            {
                AtataContext.Current.Log.Start($"Wait for {component.ComponentFullName} \"{transitionName}\" CSS transition completion", LogLevel.Trace);

                IWebElement element = searchOptions == null ? component.Scope : component.GetScope(searchOptions);
                element?.Try().Until(HasNoCssTransition, waitingOptions);

                AtataContext.Current.Log.EndSection();
            }

            return component.Owner;
        }

        private static bool HasNoCssTransition(IWebElement element)
        {
            string transitionDuration;

            try
            {
                transitionDuration = element.GetCssValue("transitionDuration");
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }

            return transitionDuration == null
                || !decimal.TryParse(transitionDuration.TrimEnd('m', 's'), out decimal transitionTime)
                || transitionTime == 0;
        }
    }
}
