namespace Atata.KendoUI;

[ControlDefinition(ContainingClass = "k-timepicker", ComponentTypeName = "time picker")]
[FindByLabel]
[IdXPathForLabel("[.//input[@id='{0}']]")]
[Format("t")]
public class KendoTimePicker<TOwner> : EditableTextField<TimeSpan?, TOwner>
    where TOwner : PageObject<TOwner>
{
    [FindFirst]
    [TraceLog]
    [Name("Associated")]
    protected TextInput<TOwner> AssociatedInput { get; private set; }

    protected override TimeSpan? GetValue()
    {
        string valueAsString = AssociatedInput.Value;
        return ConvertStringToValueUsingGetFormat(valueAsString);
    }

    protected override void SetValue(TimeSpan? value)
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
