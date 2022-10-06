namespace Atata.KendoUI.Tests;

public class KendoTimePickerTests : UITestFixture
{
    private TimePickerPage _page;

    protected override void OnSetUp() =>
        _page = Go.To<TimePickerPage>();

    [Test]
    public void Interact()
    {
        var control = _page.Regular;

        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();
        control.Should.BeNull();

        control.Set(TimeSpan.FromHours(15.5));
        control.Should.Equal(TimeSpan.FromHours(15.5));

        control.Set(null);
        control.Should.BeNull();

        control.Set(TimeSpan.FromHours(17));
        control.Should.Equal(TimeSpan.FromHours(17));

        control.Clear();
        control.Should.BeNull();
    }

    [Test]
    public void Disabled()
    {
        var control = _page.Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Equal(TimeSpan.FromHours(10.75));
    }

    [Test]
    public void ReadOnly()
    {
        var control = _page.ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Equal(TimeSpan.FromHours(17.25));
    }
}
