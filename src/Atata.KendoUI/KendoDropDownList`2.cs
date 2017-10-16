using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition("span", ContainingClass = "k-dropdown", ComponentTypeName = "drop-down list")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("@aria-owns='{0}_listbox'")]
    public class KendoDropDownList<T, TOwner> : EditableField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        private static readonly string DropDownListItemXPath =
            ".//div[contains(concat(' ', normalize-space(@class), ' '), ' k-animation-container ')]" +
            "//ul[contains(concat(' ', normalize-space(@class), ' '), ' k-list ')]" +
            "/li";

        [FindByAttribute("data-role", "dropdownlist", Visibility = Visibility.Any)]
        private Control<TOwner> DataControl { get; set; }

        [FindByClass("k-select")]
        [Name("Drop-Down")]
        [Wait(0.5)]
        protected virtual Clickable<TOwner> DropDownButton { get; set; }

        protected string ValueXPath =>
            Metadata.Get<ValueXPathAttribute>(AttributeLevels.DeclaredAndComponent)?.XPath;

        protected string ItemValueXPath =>
            Metadata.Get<ItemValueXPathAttribute>(AttributeLevels.DeclaredAndComponent)?.XPath;

        protected override T GetValue()
        {
            string value = Scope.Get(By.XPath(".//span[@class='k-input']{0}").FormatWith(ValueXPath)).Text.Trim();
            return ConvertStringToValue(value);
        }

        protected override void SetValue(T value)
        {
            string valueAsString = ConvertValueToString(value);

            DropDownButton.Click();

            GetDropDownOption(valueAsString).
                Click();
        }

        protected virtual IWebElement GetDropDownOption(string value, SearchOptions searchOptions = null)
        {
            return Driver.Get(
                By.XPath($"{DropDownListItemXPath}{ItemValueXPath}[normalize-space(.)='{value}']").
                DropDownOption(value).
                With(searchOptions));
        }

        protected override bool GetIsReadOnly()
        {
            return DataControl.Attributes.ReadOnly;
        }

        protected override bool GetIsEnabled()
        {
            return DataControl.IsEnabled;
        }
    }
}
