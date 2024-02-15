namespace Atata.KendoUI;

[ControlDefinition(ContainingClass = "k-multiselect", ComponentTypeName = "multi-select")]
[FindByLabel]
[IdXPathForLabel("[.//input[@aria-labelledby='{0}_label']]")]
[ValueXPath("span[1]")]
public class KendoMultiSelect<TOwner> : Control<TOwner>
    where TOwner : PageObject<TOwner>
{
    private const string DropDownListItemXPath =
        ".//*[contains(concat(' ', normalize-space(@class), ' '), ' k-animation-container ')]//ul/li";

    /// <summary>
    /// Gets the <see cref="ValueProvider{TValue, TOwner}"/> instance for the value indicating whether the control is read-only.
    /// By default checks "readonly" attribute of nested input element.
    /// Override <see cref="GetIsReadOnly"/> method to change the behavior.
    /// </summary>
    public ValueProvider<bool, TOwner> IsReadOnly =>
        CreateValueProvider("read-only", GetIsReadOnly);

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

        Log.ExecuteSection(
            new ValueChangeLogSection(this, "Add", value),
            () => OnAdd(value));

        ExecuteTriggers(TriggerEvents.AfterSet);

        return Owner;
    }

    protected virtual void OnAdd(string value)
    {
        AssociatedInput.Set(value);

        GetDropDownOption(value);

        Driver.Perform(x => x.SendKeys(Keys.Enter));
    }

    protected virtual IWebElement GetDropDownOption(string value, SearchOptions searchOptions = null) =>
        StaleSafely.Execute(
            opt => Driver.GetWithLogging(
                By.XPath($"{DropDownListItemXPath}{ItemValueXPath}[normalize-space(.)='{value}']")
                .DropDownOption(value)
                .Visible()
                .With(opt)),
            searchOptions ?? SearchOptions.Unsafely());

    protected virtual bool GetIsReadOnly() =>
        AssociatedInput.IsReadOnly;

    protected override bool GetIsEnabled() =>
        !DomClasses.Value.Intersect([KendoClass.Disabled, KendoClass.StateDisabled]).Any();
}
