namespace Atata.KendoUI.Tests;

public class KendoRadioButtonTests : UITestFixture
{
    private RadioButtonPage _page;

    protected override void OnSetUp() =>
        _page = Go.To<RadioButtonPage>();

    [Test]
    public void Interact()
    {
        var control = _page.Regular;

        control.Should.Exist();
        control.Should.BeEnabled();
        control.Should.Not.BeChecked();
        control.Check();
        control.Should.BeChecked();
        control.Should.Equal(true);
    }

    [Test]
    public void Disabled()
    {
        var control = _page.DisabledChecked;

        control.Should.BeDisabled();
        control.Should.Equal(true);
        control.Should.BeChecked();

        control = _page.DisabledUnchecked;

        control.Should.BeDisabled();
        control.Should.Equal(false);
        control.Should.BeUnchecked();
    }
}
