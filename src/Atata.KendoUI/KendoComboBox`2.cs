namespace Atata.KendoUI;

[ControlDefinition(ContainingClass = "k-combobox", ComponentTypeName = "combo box")]
[FindByLabel]
[IdXPathForLabel("[.//input[@aria-labelledby='{0}_label']]")]
public class KendoComboBox<T, TOwner> : EditableTextField<T, TOwner>
    where TOwner : PageObject<TOwner>
{
    [FindFirst]
    [TraceLog]
    [Name("Associated")]
    protected TextInput<TOwner> AssociatedInput { get; private set; }

    protected override T GetValue()
    {
        string valueAsString = AssociatedInput.Value;
        return ConvertStringToValueUsingGetFormat(valueAsString);
    }

    protected override void SetValue(T value)
    {
        string valueAsString = ConvertValueToStringUsingSetFormat(value);
        AssociatedInput.Set(valueAsString);
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
