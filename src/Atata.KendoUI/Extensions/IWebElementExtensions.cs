using OpenQA.Selenium;

namespace Atata.KendoUI
{
    internal static class IWebElementExtensions
    {
        public static void ClearWithHomeShiftEndDelKeys(this IWebElement element)
        {
            element.SendKeys(Keys.Home);
            AtataContext.Current.Driver.Perform(x => x.KeyDown(Keys.Shift).SendKeys(Keys.End).KeyUp(Keys.Shift));
            element.SendKeys(Keys.Delete);
        }
    }
}
