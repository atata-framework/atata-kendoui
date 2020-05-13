using System;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    /// <summary>
    /// Represents the Kendo UI date picker control for Angular.
    /// Default search is performed by the label.
    /// The default format is <c>"d"</c> (short date pattern, e.g. <c>6/15/2009</c>).
    /// The default value set format is <c>"MMddyyyy"</c>.
    /// Handles any element with <c>k-datepicker</c> class.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner page object.</typeparam>
    [ValueSetFormat("MMddyyyy")]
    public class NgKendoDatePicker<TOwner> : KendoDatePicker<TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override void SetValue(DateTime? value)
        {
            if (value == null)
                OnClear();
            else
                base.SetValue(value);
        }

        protected virtual void OnClear()
        {
            AssociatedInput.Scope.Click();
            Driver.Perform(x => x.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete));
        }
    }
}
