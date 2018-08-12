using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-multiselect", ComponentTypeName = "multi-select")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[ul[id='{0}_taglist']]")]
    [ValueXPath("span[1]")]
    public class KendoMultiSelect<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        private static readonly string DropDownListItemXPath =
            ".//*[contains(concat(' ', normalize-space(@class), ' '), ' k-animation-container ')]" +
            "//ul[contains(concat(' ', normalize-space(@class), ' '), ' k-list ')]" +
            "/li";

        [FindFirst]
        [TraceLog]
        [Name("Associated")]
        [Format(null)]
        protected TextInput<TOwner> AssociatedInput { get; private set; }

        protected string ValueXPath =>
            Metadata.Get<ValueXPathAttribute>(AttributeLevels.DeclaredAndComponent)?.XPath;

        protected string ItemValueXPath =>
            Metadata.Get<ItemValueXPathAttribute>(AttributeLevels.DeclaredAndComponent)?.XPath;

        public TOwner Add(string value)
        {
            ExecuteTriggers(TriggerEvents.BeforeSet);
            Log.Start(new DataAdditionLogSection(this, value));

            OnAdd(value);

            Log.EndSection();
            ExecuteTriggers(TriggerEvents.AfterSet);

            return Owner;
        }

        protected virtual void OnAdd(string value)
        {
            AssociatedInput.Set(value);

            GetDropDownOption(value);

            Driver.Perform(x => x.SendKeys(Keys.Enter));
        }

        protected virtual IWebElement GetDropDownOption(string value, SearchOptions searchOptions = null)
        {
            return Driver.Get(
                By.XPath($"{DropDownListItemXPath}{ItemValueXPath}[normalize-space(.)='{value}']").
                DropDownOption(value).
                With(searchOptions));
        }
    }
}
