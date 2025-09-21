namespace Atata.KendoUI;

[ControlDefinition(ContainingClass = "k-numerictextbox", ComponentTypeName = "numeric text box")]
[FindByLabel]
[IdXPathForLabel("[span/input[@id='{0}']]")]
public class KendoNumericTextBox<TValue, TOwner> : EditableTextField<TValue, TOwner>
    where TOwner : PageObject<TOwner>
{
    [FindFirst(Visibility = Visibility.Visible)]
    [TraceLog]
    [Name("Associated")]
    [ControlDefinition("input[not(@type) or (@type!='button' and @type!='submit' and @type!='reset')]", ComponentTypeName = "input")]
    [ClearsValueUsingCtrlADeleteKeys]
    protected Input<string, TOwner> AssociatedInput { get; private set; } = null!;

    protected override TValue GetValue()
    {
        string valueAsString = AssociatedInput.Script.ExecuteAgainst<string>(
            "return (arguments[0] === document.activeElement || !arguments[0].hasAttribute('aria-valuenow')) ? arguments[0].value : arguments[0].getAttribute('aria-valuenow');");

        return ConvertStringToValueUsingGetFormat(valueAsString)!;
    }

    protected override void SetValue(TValue value)
    {
        OnClear();

        string? valueAsString = ConvertValueToStringUsingSetFormat(value);

        if (valueAsString?.Length > 0)
            OnType(valueAsString);
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
