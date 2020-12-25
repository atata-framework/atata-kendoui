using System.Linq;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-dropdown", ComponentTypeName = "drop-down list")]
    [FindByLabel]
    [IdXPathForLabel("@aria-owns='{0}_listbox'")]
    public class KendoDropDownList<T, TOwner> : EditableField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        private const string DropDownListItemXPath =
            ".//*[contains(concat(' ', normalize-space(@class), ' '), ' k-animation-container ')]" +
            "//ul[contains(concat(' ', normalize-space(@class), ' '), ' k-list ')]" +
            "/li";

        /// <summary>
        /// Gets or sets the waiting options of open animation.
        /// Uses <see cref="KendoPopup{TOwner}.DefaultAnimationWaitingOptions"/> as default value.
        /// </summary>
        protected RetryOptions OpenAnimationWaitingOptions { get; set; } = KendoPopup<TOwner>.DefaultAnimationWaitingOptions;

        /// <summary>
        /// Gets or sets the waiting options of close animation.
        /// Uses <see cref="KendoPopup{TOwner}.DefaultAnimationWaitingOptions"/> as default value.
        /// </summary>
        protected RetryOptions CloseAnimationWaitingOptions { get; set; } = KendoPopup<TOwner>.DefaultAnimationWaitingOptions;

        [FindByClass("k-dropdown-wrap")]
        [TraceLog]
        protected Control<TOwner> WrapControl { get; private set; }

        [FindByClass("k-select")]
        [Name("Drop-Down")]
        [TraceLog]
        protected Control<TOwner> DropDownButton { get; private set; }

        [FindFirst(ScopeSource = ScopeSource.Page)]
        [Name("Drop-Down")]
        [TraceLog]
        protected KendoPopup<TOwner> Popup { get; private set; }

        protected string ValueXPath =>
            Metadata.Get<ValueXPathAttribute>(x => x.At(AttributeLevels.DeclaredAndComponent))?.XPath;

        protected string ItemValueXPath =>
            Metadata.Get<ItemValueXPathAttribute>(x => x.At(AttributeLevels.DeclaredAndComponent))?.XPath;

        protected override T GetValue()
        {
            string value = Scope.GetWithLogging(By.XPath(".//span[contains(concat(' ', normalize-space(@class), ' '), ' k-input ')]{0}").FormatWith(ValueXPath))
                .Text.Trim();

            return ConvertStringToValueUsingGetFormat(value);
        }

        protected override void SetValue(T value)
        {
            string valueAsString = ConvertValueToStringUsingSetFormat(value);

            DropDownButton.Click();

            if (Popup.IsPresent)
                Popup.WaitUntilOpen(OpenAnimationWaitingOptions);

            GetDropDownOption(valueAsString).
                Click();

            Popup.WaitUntilClosed(CloseAnimationWaitingOptions);
        }

        protected virtual IWebElement GetDropDownOption(string value, SearchOptions searchOptions = null)
        {
            return Driver.GetWithLogging(
                By.XPath($"{DropDownListItemXPath}{ItemValueXPath}[normalize-space(.)='{value}']").
                DropDownOption(value).
                With(searchOptions));
        }

        protected override bool GetIsReadOnly()
        {
            return Scope.GetWithLogging(By.XPath(".//*[@readonly and @readonly!='false']").OfAnyVisibility().SafelyAtOnce()) != null;
        }

        protected override bool GetIsEnabled()
        {
            return !WrapControl.Attributes.Class.Value.Contains(KendoClass.Disabled);
        }
    }
}
