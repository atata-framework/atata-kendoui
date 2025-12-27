namespace Atata.KendoUI.Tests;

public sealed class KendoSwitchTests : UITestSuite
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<SwitchPage>(library).Regular;

        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();
        control.Should.BeFalse();
        control.Should.Not.BeChecked();

        control.Set(true);
        control.Should.BeTrue();
        control.Should.BeChecked();

        control.Uncheck();
        control.Should.BeFalse();
        control.IsChecked.Should.BeFalse();

        control.Check();
        control.Should.BeTrue();
        control.IsChecked.Should.BeTrue();

        control.Toggle();
        control.Toggle();
        control.Toggle();

        control.Should.BeFalse();
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<SwitchPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.BeTrue();
        control.Should.BeChecked();
    }

    [TestCaseSources.JQuery]
    public void FindByLabel(string library)
    {
        var control = GoToTestPage<SwitchPage>(library).FindsByLabel;

        control.Should.BeEnabled();
        control.Should.BeFalse();

        control.Check();
        control.Should.BeTrue();
    }
}
