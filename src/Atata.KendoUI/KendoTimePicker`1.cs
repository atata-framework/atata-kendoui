using System;
using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition("span", ContainingClass = "k-timepicker", ComponentTypeName = "time picker")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[.//input[@id='{0}']]")]
    [Format("t")]
    public class KendoTimePicker<TOwner> : EditableField<TimeSpan?, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst]
        private TextInput<TOwner> DataControl { get; set; }

        protected override TimeSpan? GetValue()
        {
            string valueAsString = DataControl.Value;
            return ConvertStringToValue(valueAsString);
        }

        protected override void SetValue(TimeSpan? value)
        {
            string valueAsString = ConvertValueToString(value);
            Scope.Get(By.TagName("input").Input()).FillInWith(valueAsString);
        }

        protected override bool GetIsReadOnly()
        {
            return DataControl.Attributes.ReadOnly;
        }

        protected override bool GetIsEnabled()
        {
            return DataControl.IsEnabled;
        }
    }
}
