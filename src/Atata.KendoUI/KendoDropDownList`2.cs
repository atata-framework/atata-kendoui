namespace Atata.KendoUI;

[ControlDefinition(
    "*[contains(concat(' ', normalize-space(@class), ' '), ' k-dropdownlist ') or contains(concat(' ', normalize-space(@class), ' '), ' k-dropdown ')]",
    ComponentTypeName = "drop-down list")]
[FindByLabel]
[IdXPathForLabel("@aria-labelledby='{0}_label'")]
public class KendoDropDownList<TValue, TOwner> : EditableField<TValue, TOwner>
    where TOwner : PageObject<TOwner>
{
    private const string DropDownListItemXPath =
        ".//*[contains(concat(' ', normalize-space(@class), ' '), ' k-animation-container ')]//ul/li";

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
    protected Control<TOwner> WrapControl { get; private set; } = null!;

    [FindFirst(ScopeSource = ScopeSource.Page, Visibility = Visibility.Visible)]
    [Name("Drop-Down")]
    [TraceLog]
    protected KendoPopup<TOwner> Popup { get; private set; } = null!;

    protected string? ValueXPath =>
        Metadata.Get<ValueXPathAttribute>(x => x.At(AttributeLevels.DeclaredAndComponent))?.XPath;

    protected string? ItemValueXPath =>
        Metadata.Get<ItemValueXPathAttribute>(x => x.At(AttributeLevels.DeclaredAndComponent))?.XPath;

    protected override TValue GetValue()
    {
        string value = Scope.GetWithLogging(
            By.XPath($".//span[contains(concat(' ', normalize-space(@class), ' '), ' k-input-value-text ') or contains(concat(' ', normalize-space(@class), ' '), ' k-input ')]{ValueXPath}")
                .Visible())!
            .Text.Trim();

        return ConvertStringToValueUsingGetFormat(value)!;
    }

    protected override void SetValue(TValue value)
    {
        string? valueAsString = ConvertValueToStringUsingSetFormat(value);

        Click();

        if (Popup.IsPresent)
            Popup.WaitUntilOpen(OpenAnimationWaitingOptions);

        GetDropDownOption(valueAsString)!
            .ClickWithLogging();

        Popup.WaitUntilClosed(CloseAnimationWaitingOptions);
    }

    protected virtual IWebElement? GetDropDownOption(string? value, SearchOptions? searchOptions = null)
    {
        By by = By.XPath($"{DropDownListItemXPath}{ItemValueXPath}[normalize-space(.)='{value}']")
            .DropDownOption(value)
            .Visible();

        if (searchOptions is not null)
            by = by.With(searchOptions);

        return Driver.GetWithLogging(by);
    }

    protected override bool GetIsReadOnly() =>
        Scope.GetWithLogging(By.XPath(".//*[@readonly and @readonly!='false']").OfAnyVisibility().SafelyAtOnce()) != null;

    protected override bool GetIsEnabled()
    {
        var domClasses = DomClasses.Value;

        return domClasses.Contains("k-dropdownlist")
            ? !domClasses.Contains(KendoClass.Disabled)
            : !WrapControl.DomClasses.Value.Contains(KendoClass.StateDisabled);
    }
}
