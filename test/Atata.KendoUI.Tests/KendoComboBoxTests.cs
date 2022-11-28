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
        control.Should.Equal("Some value");

        control.SetRandom(out string randomValue);
        control.Should.Equal(randomValue);

        control.Clear();
        control.Should.BeEmpty();
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<ComboBoxPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Equal("Item 1");
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<ComboBoxPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Equal(ComboBoxPage.ItemValue.Item2);
    }
}
