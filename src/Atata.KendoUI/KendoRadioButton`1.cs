namespace Atata.KendoUI;

[ControlDefinition("input[@type='radio']", ContainingClass = "k-radio", ComponentTypeName = "radio button", Visibility = Visibility.Any, IgnoreNameEndings = "RadioButton,Radio,Button,Option")]
public class KendoRadioButton<TOwner> : RadioButton<TOwner>
    where TOwner : PageObject<TOwner>
{
    [FindFirst(OuterXPath = "following-sibling::")]
    [TraceLog]
    private Label<TOwner> AssociatedLabel { get; set; }

    protected override void OnClick() =>
        AssociatedLabel.Click();
}
