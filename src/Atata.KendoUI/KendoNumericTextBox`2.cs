using System.Linq;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-numerictextbox", ComponentTypeName = "numeric text box")]
    [FindByLabel]
    [IdXPathForLabel("[span/input[2][@id='{0}']]")]
    public class KendoNumericTextBox<T, TOwner> : EditableTextField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst(Visibility = Visibility.Visible)]
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
            OnClear();

            string valueAsString = ConvertValueToStringUsingSetFormat(value);

            if (!string.IsNullOrEmpty(valueAsString))
                OnType(valueAsString);
        }

        protected virtual void EnsureFocused()
        {
            IWebElement formattedValueInput = Scope.GetWithLogging(By.CssSelector($"input.{KendoClass.FormattedValue}").Input().OfAnyVisibility().SafelyAtOnce());

            if (formattedValueInput != null && formattedValueInput.Displayed)
                formattedValueInput.ClickWithLogging();
        }

        protected override bool GetIsReadOnly()
        {
            return AssociatedInput.IsReadOnly;
        }

        protected override bool GetIsEnabled()
        {
            return AssociatedInput.IsEnabled;
        }

        protected override void OnClear()
        {
            EnsureFocused();

            AssociatedInput.Clear();
            AssociatedInput.Type("0" + Keys.Backspace);
        }

        protected override void OnType(string text)
        {
            EnsureFocused();

            AssociatedInput.Type(text);
        }
    }
}
