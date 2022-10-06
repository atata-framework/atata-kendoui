using System;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    /// <summary>
    /// Represents the Kendo UI date picker control.
    /// Default search is performed by the label.
    /// The default format is <c>"d"</c> (short date pattern, e.g. <c>6/15/2009</c>).
    /// Handles any element with <c>k-datepicker</c> class.
    /// <para>
    /// When using Kendo UI for Angular prefer to use <see cref="NgKendoDatePicker{TOwner}"/> control instead.
    /// </para>
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner page object.</typeparam>
    [ControlDefinition(ContainingClass = "k-datepicker", ComponentTypeName = "date picker")]
    [FindByLabel]
    [IdXPathForLabel("[.//input[@id='{0}']]")]
    [Format("d")]
    public class KendoDatePicker<TOwner> : EditableTextField<DateTime?, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst]
        [TraceLog]
        [Name("Associated")]
        [ClearsValueUsingCtrlADeleteKeys]
        protected TextInput<TOwner> AssociatedInput { get; private set; }

        protected override DateTime? GetValue()
        {
            string valueAsString = AssociatedInput.Value;
            return ConvertStringToValueUsingGetFormat(valueAsString);
        }

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

            OnClear();

            if (!string.IsNullOrEmpty(valueAsString))
            {
                IWebElement scope = AssociatedInput.Scope;

                scope.SendKeys(Keys.Home);

                foreach (char key in valueAsString)
                {
                    if (!char.IsLetterOrDigit(key))
                        Owner.WaitSeconds(0.1);

                    scope.SendKeys(key.ToString());

                    if (!char.IsLetterOrDigit(key))
                        Owner.WaitSeconds(0.1);
                }
            }
        }

        protected override bool GetIsReadOnly() =>
            AssociatedInput.IsReadOnly;

        protected override bool GetIsEnabled() =>
            AssociatedInput.IsEnabled;

        protected override void OnClear() =>
            AssociatedInput.Clear();

        protected override void OnType(string text) =>
            AssociatedInput.Type(text);
    }
}
