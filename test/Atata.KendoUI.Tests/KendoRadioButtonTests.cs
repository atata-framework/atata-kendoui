namespace Atata.KendoUI.Tests;

public class KendoRadioButtonTests : UITestFixture
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<RadioButtonPage>(library).Regular;

        control.Should.BePresent();
        control.Should.BeEnabled();
        control.Should.Not.BeChecked();
        control.Check();
        control.Should.BeChecked();
        control.Should.Equal(true);
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var page = GoToTestPage<RadioButtonPage>(library);
        var control = page.DisabledChecked;

        control.Should.BeDisabled();
        control.Should.Equal(true);
        control.Should.BeChecked();

        control = page.DisabledUnchecked;

        control.Should.BeDisabled();
        control.Should.Equal(false);
        control.Should.BeUnchecked();
    }
}
