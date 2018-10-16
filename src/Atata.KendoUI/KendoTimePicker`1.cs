using System;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-timepicker", ComponentTypeName = "time picker")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[.//input[@id='{0}']]")]
    [Format("t")]
    public class KendoTimePicker<TOwner> : EditableField<TimeSpan?, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst]
        [TraceLog]
        [Name("Associated")]
        protected TextInput<TOwner> AssociatedInput { get; private set; }

        protected override TimeSpan? GetValue()
        {
            string valueAsString = AssociatedInput.Value;
            return ConvertStringToValue(valueAsString);
        }

        protected override void SetValue(TimeSpan? value)
        {
            string valueAsString = ConvertValueToString(value);
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
