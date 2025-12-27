namespace Atata.KendoUI.Tests;

public sealed class KendoTimePickerTests : UITestSuite
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<TimePickerPage>(library).Regular;

        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();
        control.Should.BeNull();

        control.Set(TimeSpan.FromHours(15.5));
        control.Should.Be(TimeSpan.FromHours(15.5));

        control.Set(null);
        control.Should.BeNull();

        control.Set(TimeSpan.FromHours(17));
        control.Should.Be(TimeSpan.FromHours(17));

        control.Clear();
        control.Should.BeNull();
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<TimePickerPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Be(TimeSpan.FromHours(10.75));
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<TimePickerPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Be(TimeSpan.FromHours(17.25));
    }
}
