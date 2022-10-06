using System.Linq;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-numerictextbox", ComponentTypeName = "numeric text box")]
    [FindByLabel]
    [IdXPathForLabel("[span/input[2][@id='{0}']]")]
    public class KendoNumericTextBox<T, TOwner> : EditableTextField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst(Visibility = Visibility.Visible)]
        [TraceLog]
        [Name("Associated")]
        [ControlDefinition("input[not(@type) or (@type!='button' and @type!='submit' and @type!='reset')]", ComponentTypeName = "input")]
        [ClearsValueUsingCtrlADeleteKeys]
        protected Input<string, TOwner> AssociatedInput { get; private set; }

        protected override T GetValue()
        {
            string valueAsString = AssociatedInput.Attributes.Class.Value.Contains(KendoClass.FormattedValue)
                ? AssociatedInput.Attributes["aria-valuenow"]
                : AssociatedInput.Value;

            return ConvertStringToValueUsingGetFormat(valueAsString);
        }

        protected override void SetValue(T value)
        {
            OnClear();

            string valueAsString = ConvertValueToStringUsingSetFormat(value);

            if (!string.IsNullOrEmpty(valueAsString))
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
}
