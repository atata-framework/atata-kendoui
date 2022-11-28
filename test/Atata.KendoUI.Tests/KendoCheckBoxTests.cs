namespace Atata.KendoUI.Tests;

public class KendoCheckBoxTests : UITestFixture
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<CheckBoxPage>(library).Regular;

        control.Should.Exist();
        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();
        control.Should.BeChecked();
        control.Uncheck();
        control.Should.BeUnchecked();
        control.Set(true);
        control.Should.BeChecked();
        control.Should.Equal(true);
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var page = GoToTestPage<CheckBoxPage>(library);
        var control = page.DisabledChecked;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Equal(true);
        control.Should.BeChecked();

        control = page.DisabledUnchecked;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Equal(false);
        control.Should.BeUnchecked();
    }
}
