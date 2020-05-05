using System.Linq;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-numerictextbox", ComponentTypeName = "numeric text box")]
    [FindByLabel]
    [IdXPathForLabel("[span/input[2][@id='{0}']]")]
    public class KendoNumericTextBox<T, TOwner> : EditableField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst]
        [TraceLog]
        [Name("Associated")]
        [ControlDefinition("input[not(@type) or (@type!='button' and @type!='submit' and @type!='reset')]", ComponentTypeName = "input")]
        protected Input<string, TOwner> AssociatedInput { get; private set; }

        protected override T GetValue()
        {
            string valueAsString = AssociatedInput.Attributes.Class.Value.Contains(KendoClass.FormattedValue)
                ? AssociatedInput.Attributes["aria-valuenow"]
                : AssociatedInput.Value;

            return ConvertStringToValueUsingGetFormat(valueAsString);
        }

        protected override void SetValue(T value)
        {
            EnsureFocused();

            AssociatedInput.Scope.Clear();

            EnsureFocused();

            string valueAsString = ConvertValueToStringUsingSetFormat(value);

            string keysToSend = string.IsNullOrEmpty(valueAsString)
                ? "0" + Keys.Backspace
                : valueAsString;

            AssociatedInput.Scope.SendKeys(keysToSend);
        }

        protected virtual void EnsureFocused()
        {
            IWebElement formattedValueInput = Scope.Get(By.CssSelector($"input.{KendoClass.FormattedValue}").Input().OfAnyVisibility().SafelyAtOnce());

            if (formattedValueInput != null && formattedValueInput.Displayed)
                formattedValueInput.Click();
        }

        protected override bool GetIsReadOnly()
        {
            return AssociatedInput.IsReadOnly;
        }

        protected override bool GetIsEnabled()
        {
            return AssociatedInput.IsEnabled;
        }
    }
}
