namespace Atata.KendoUI.Tests;

public class KendoComboBoxTests : UITestFixture
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<ComboBoxPage>(library).Regular;

        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set("Some value");
        control.Should.Be("Some value");

        control.SetRandom(out string randomValue);
        control.Should.Be(randomValue);

        control.Clear();
        control.Should.BeEmpty();
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<ComboBoxPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Be("Item 1");
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<ComboBoxPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Be(ComboBoxPage.ItemValue.Item2);
    }
}
