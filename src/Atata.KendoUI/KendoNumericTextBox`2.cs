using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition("span", ContainingClass = "k-numerictextbox", ComponentTypeName = "numeric text box")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[span/input[2][@id='{0}']]")]
    public class KendoNumericTextBox<T, TOwner> : EditableField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByAttribute("data-role", "numerictextbox", Visibility = Visibility.Any)]
        [TraceLog]
        private TextInput<TOwner> DataInput { get; set; }

        protected override T GetValue()
        {
            string valueAsString = DataInput.Get();
            return ConvertStringToValue(valueAsString);
        }

        protected override void SetValue(T value)
        {
            IWebElement formattedValueInput = Scope.Get(By.CssSelector("input.k-formatted-value").Input().OfAnyVisibility().AtOnce());

            if (formattedValueInput.Displayed)
                formattedValueInput.Click();

            string valueAsString = ConvertValueToString(value);
            Scope.Get(By.TagName("input").Input()).FillInWith(valueAsString);
        }

        protected override bool GetIsReadOnly()
        {
            return DataInput.IsReadOnly;
        }

        protected override bool GetIsEnabled()
        {
            return DataInput.IsEnabled;
        }
    }
}
