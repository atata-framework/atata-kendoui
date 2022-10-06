namespace Atata.KendoUI.Tests;

public class KendoMultiSelectTests : UITestFixture
{
    private MultiSelectPage _page;

    protected override void OnSetUp() =>
        _page = Go.To<MultiSelectPage>();

    [Test]
    public void Interact()
    {
        var control = _page.Regular;

        control.Should.BeEnabled();
        control.IsReadOnly.Should.BeFalse();
        control.Add("Item 4");
        control.Add("Item 2");
    }

    [Test]
    public void Disabled()
    {
        var control = _page.Disabled;

        control.Should.BeDisabled();
        control.IsReadOnly.Should.BeFalse();
    }

    [Test]
    public void ReadOnly()
    {
        var control = _page.ReadOnly;

        control.Should.BeEnabled();
        control.IsReadOnly.Should.BeTrue();
    }

    [Test]
    public void SlowAnimation() =>
        _page
            .SlowAnimating.Add("Item 5")
            .Regular.Add("Item 3");
}
