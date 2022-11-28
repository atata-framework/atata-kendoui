namespace Atata.KendoUI.Tests;

public class KendoMultiSelectTests : UITestFixture
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<MultiSelectPage>(library).Regular;

        control.Should.BeEnabled();
        control.IsReadOnly.Should.BeFalse();
        control.Add("Item 4");
        control.Add("Item 2");
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<MultiSelectPage>(library).Disabled;

        control.Should.BeDisabled();
        control.IsReadOnly.Should.BeFalse();
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<MultiSelectPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.IsReadOnly.Should.BeTrue();
    }

    [TestCaseSources.JQuery]
    public void SlowAnimation(string library) =>
        GoToTestPage<MultiSelectPage>(library)
            .SlowAnimating.Add("Item 5")
            .Regular.Add("Item 3");
}
