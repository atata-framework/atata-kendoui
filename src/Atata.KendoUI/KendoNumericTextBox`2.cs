using System.Linq;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-numerictextbox", ComponentTypeName = "numeric text box")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[span/input[2][@id='{0}']]")]
    public class KendoNumericTextBox<T, TOwner> : EditableField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst]
        [TraceLog]
        [Name("Associated")]
        protected Input<string, TOwner> AssociatedInput { get; private set; }

        protected override T GetValue()
        {
            string valueAsString = AssociatedInput.Attributes.Class.Value.Contains(KendoClass.FormattedValue)
                ? AssociatedInput.Attributes["aria-valuenow"]
                : AssociatedInput.Value;

            return ConvertStringToValue(valueAsString);
        }

        protected override void SetValue(T value)
        {
            IWebElement formattedValueInput = Scope.Get(By.CssSelector($"input.{KendoClass.FormattedValue}").Input().OfAnyVisibility().SafelyAtOnce());

            if (formattedValueInput != null && formattedValueInput.Displayed)
                formattedValueInput.Click();

            string valueAsString = ConvertValueToString(value);
            AssociatedInput.Set(valueAsString);
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
