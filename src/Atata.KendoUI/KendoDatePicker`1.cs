using System;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-datepicker", ComponentTypeName = "date picker")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[.//input[@id='{0}']]")]
    [Format("d")]
    public class KendoDatePicker<TOwner> : EditableField<DateTime?, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst]
        [TraceLog]
        [Name("Associated")]
        protected TextInput<TOwner> AssociatedInput { get; private set; }

        protected override DateTime? GetValue()
        {
            string valueAsString = AssociatedInput.Value;
            return ConvertStringToValue(valueAsString);
        }

        protected override DateTime? ConvertStringToValue(string value)
        {
            try
            {
                return base.ConvertStringToValue(value);
            }
            catch
            {
                return null;
            }
        }

        protected override void SetValue(DateTime? value)
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
