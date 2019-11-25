using System;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    /// <summary>
    /// Represents the Kendo UI date input control for Angular.
    /// Default search is performed by the label.
    /// The default format is <c>"d"</c> (short date pattern, e.g. <c>6/15/2009</c>).
    /// The default value set format is <c>"MMddyyyy"</c>.
    /// Handles any <c>input</c> element with <c>type="date"</c>, <c>type="text"</c> or without the defined <c>type</c> attribute
    /// and which has a parent element containing either class <c>k-dateinput</c> or <c>k-dateinput-wrap</c>.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner.</typeparam>
    [ValueSetFormat("MMddyyyy")]
    public class NgKendoDateInput<TOwner> : KendoDateInput<TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override void SetValue(DateTime? value)
        {
            if (value == null)
                OnClear();
            else
                base.SetValue(value);
        }

        protected override void OnClear()
        {
            Driver.Perform(x => x.KeyDown(Scope, Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete));
        }
    }
}
