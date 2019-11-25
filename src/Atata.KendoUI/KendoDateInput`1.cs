using System;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    /// <summary>
    /// Represents the Kendo UI date input control.
    /// Default search is performed by the label.
    /// The default format is <c>"d"</c> (short date pattern, e.g. <c>6/15/2009</c>).
    /// Handles any <c>input</c> element with <c>type="date"</c>, <c>type="text"</c> or without the defined <c>type</c> attribute
    /// and which has a parent element containing either class <c>k-dateinput</c> or <c>k-dateinput-wrap</c>.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner.</typeparam>
    [ControlDefinition("input[@type='text' or @type='date' or not(@type)][parent::*[contains(concat(' ', normalize-space(@class), ' '), ' k-dateinput ') or contains(concat(' ', normalize-space(@class), ' '), ' k-dateinput-wrap ')]]", ComponentTypeName = "date input")]
    [Format("d")]
    public class KendoDateInput<TOwner> : DateInput<TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override DateTime? ConvertStringToValueUsingGetFormat(string value)
        {
            try
            {
                return base.ConvertStringToValueUsingGetFormat(value);
            }
            catch
            {
                return null;
            }
        }

        protected override void SetValue(DateTime? value)
        {
            string valueAsString = ConvertValueToStringUsingSetFormat(value);
            Scope.FillInWith(Keys.Home + valueAsString);
        }
    }
}
