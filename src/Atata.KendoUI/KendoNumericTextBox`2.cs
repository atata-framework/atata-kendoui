using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition("span", ContainingClass = "k-numerictextbox", ComponentTypeName = "numeric text box")]
    [IdXPathForLabel("[span/input[2][@id='{0}']]")]
    public class KendoNumericTextBox<T, TOwner> : EditableField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override T GetValue()
        {
            string valueAsString = Scope.Get(By.CssSelector("input[data-role='numerictextbox']").Input().OfAnyVisibility()).GetValue();
            return ConvertStringToValue(valueAsString);
        }

        protected override void SetValue(T value)
        {
            IWebElement formattedValueInput = Scope.Get(By.CssSelector("input.k-formatted-value").Input().OfAnyVisibility().AtOnce());

            if (formattedValueInput.Displayed)
                formattedValueInput.Click();

            string valueAsString = ConvertValueToString(value);
            Scope.Get(By.CssSelector("input")).FillInWith(valueAsString);
        }
    }
}
