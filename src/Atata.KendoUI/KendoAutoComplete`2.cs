namespace Atata.KendoUI;

/// <summary>
/// Represents the Kendo UI auto-complete control.
/// Default search is performed by the label.
/// Handles any element with <c>k-autocomplete</c> class.
/// <para>
/// When using Kendo UI for React prefer to use <see cref="ReactKendoAutoComplete{T, TOwner}"/> control instead.
/// </para>
/// </summary>
/// <typeparam name="TValue">The type of the control's value.</typeparam>
/// <typeparam name="TOwner">The type of the owner page object.</typeparam>
[ControlDefinition(ContainingClass = "k-autocomplete", ComponentTypeName = "auto-complete")]
[FindByLabel]
[IdXPathForLabel("[.//input[@id='{0}']]")]
public class KendoAutoComplete<TValue, TOwner> : EditableTextField<TValue, TOwner>
    where TOwner : PageObject<TOwner>
{
    [FindFirst]
    [TraceLog]
    [Name("Associated")]
    protected TextInput<TOwner> AssociatedInput { get; private set; } = null!;

    protected override TValue GetValue()
    {
        string valueAsString = AssociatedInput.Value;
        return ConvertStringToValueUsingGetFormat(valueAsString)!;
    }

    protected override void SetValue(TValue value)
    {
        string? valueAsString = ConvertValueToStringUsingSetFormat(value);
        AssociatedInput.Set(valueAsString ?? string.Empty);
    }

    protected override bool GetIsReadOnly() =>
        AssociatedInput.IsReadOnly;

    protected override bool GetIsEnabled() =>
        AssociatedInput.IsEnabled;

    protected override void OnClear() =>
        AssociatedInput.Clear();

    protected override void OnType(string text) =>
        AssociatedInput.Type(text);
}
