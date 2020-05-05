using System.Linq;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-multiselect", ComponentTypeName = "multi-select")]
    [FindByLabel]
    [IdXPathForLabel("[.//ul[@id='{0}_taglist']]")]
    [ValueXPath("span[1]")]
    public class KendoMultiSelect<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        private const string DropDownListItemXPath =
            ".//*[contains(concat(' ', normalize-space(@class), ' '), ' k-animation-container ')]" +
            "//ul[contains(concat(' ', normalize-space(@class), ' '), ' k-list ')]" +
            "/li";

        /// <summary>
        /// Gets the <see cref="DataProvider{TData, TOwner}"/> instance for the value indicating whether the control is read-only.
        /// By default checks "readonly" attribute of nested input element.
        /// Override <see cref="GetIsReadOnly"/> method to change the behavior.
        /// </summary>
        public DataProvider<bool, TOwner> IsReadOnly => GetOrCreateDataProvider("read-only", GetIsReadOnly);

        [FindFirst]
        [TraceLog]
        [Name("Associated")]
        protected TextInput<TOwner> AssociatedInput { get; private set; }

        protected string ValueXPath =>
            Metadata.Get<ValueXPathAttribute>(x => x.At(AttributeLevels.DeclaredAndComponent))?.XPath;

        protected string ItemValueXPath =>
            Metadata.Get<ItemValueXPathAttribute>(x => x.At(AttributeLevels.DeclaredAndComponent))?.XPath;

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
            return StaleSafely.Execute(
                opt => Driver.Get(
                    By.XPath($"{DropDownListItemXPath}{ItemValueXPath}[normalize-space(.)='{value}']").
                    DropDownOption(value).
                    With(opt)),
                searchOptions ?? SearchOptions.Unsafely());
        }

        protected virtual bool GetIsReadOnly()
        {
            return AssociatedInput.IsReadOnly;
        }

        protected override bool GetIsEnabled()
        {
            return !Attributes.Class.Value.Contains(KendoClass.Disabled);
        }
    }
}
