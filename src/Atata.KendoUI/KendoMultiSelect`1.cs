using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition("div", ContainingClass = "k-multiselect", ComponentTypeName = "multi-select")]
    [IdXPathForLabel("[ul[id='{0}_taglist']]")]
    [ValueXPath("span[1]")]
    public class KendoMultiSelect<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        private static readonly string DropDownListItemXPath =
            ".//div[contains(concat(' ', normalize-space(@class), ' '), ' k-animation-container ')]" +
            "//ul[contains(concat(' ', normalize-space(@class), ' '), ' k-list ')]" +
            "/li";

        [FindByClass("k-input")]
        protected virtual TextInput<TOwner> Input { get; set; }

        protected string ValueXPath
        {
            get { return Metadata.Get<ValueXPathAttribute>(AttributeLevels.DeclaredAndComponent)?.XPath; }
        }

        protected string ItemValueXPath
        {
            get { return Metadata.Get<ItemValueXPathAttribute>(AttributeLevels.DeclaredAndComponent)?.XPath; }
        }

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
            Input.Set(value);

            GetDropDownOption(value);

            Driver.Perform(x => x.SendKeys(Keys.Enter));

            ////Scope.Get(By.XPath(".//ul/li{0}[normalize-space(.)='{1}']").FormatWith(ValueXPath, value).OfKind("added item element", value));
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
