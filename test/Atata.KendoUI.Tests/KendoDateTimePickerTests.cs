namespace Atata.KendoUI.Tests;

public class KendoDateTimePickerTests : UITestFixture
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<DateTimePickerPage>(library).Regular;

        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();
        control.Should.BeNull();

        DateTime value = new DateTime(2018, 7, 11, 15, 30, 0);
        control.Set(value);
        control.Should.Equal(value);

        control.Set(null);
        control.Should.BeNull();

        value = new DateTime(1998, 11, 2, 19, 15, 0);
        control.Set(value);
        control.Should.Equal(value);

        control.Clear();
        control.Should.BeNull();
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<DateTimePickerPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Equal(new DateTime(2000, 10, 10));
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<DateTimePickerPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Equal(new DateTime(2005, 7, 20, 17, 45, 0));
    }
}
