namespace Atata.KendoUI
{
    [ControlDefinition("input[@type='checkbox']", ComponentTypeName = "checkbox", Visibility = Visibility.Any, IgnoreNameEndings = "Checkbox,CheckBox,Option")]
    public class KendoCheckBox<TOwner> : CheckBox<TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindFirst(OuterXPath = "following-sibling::")]
        [TraceLog]
        private Label<TOwner> LabelControl { get; set; }

        protected override void SetValue(bool value)
        {
            if (Scope.Selected != value)
                LabelControl.Click();
        }
    }
}
