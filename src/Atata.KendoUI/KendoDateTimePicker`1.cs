using System;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-datetimepicker", ComponentTypeName = "date/time picker")]
    [FindByLabel]
    [IdXPathForLabel("[.//input[@id='{0}']]")]
    [Format("g")]
    public class KendoDateTimePicker<TOwner> : EditableTextField<DateTime?, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst]
        [TraceLog]
        [Name("Associated")]
        protected TextInput<TOwner> AssociatedInput { get; private set; }

        protected override DateTime? GetValue()
        {
            string valueAsString = AssociatedInput.Value;
            return ConvertStringToValueUsingGetFormat(valueAsString);
        }

        protected override void SetValue(DateTime? value)
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
}
