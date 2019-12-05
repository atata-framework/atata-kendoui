namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-combobox", ComponentTypeName = "combo box")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[.//input[@aria-owns='{0}_listbox']]")]
    public class KendoComboBox<T, TOwner> : EditableField<T, TOwner>
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

        protected override bool GetIsReadOnly()
        {
            return AssociatedInput.IsReadOnly;
        }

        protected override bool GetIsEnabled()
        {
            return AssociatedInput.IsEnabled;
        }
    }
}
