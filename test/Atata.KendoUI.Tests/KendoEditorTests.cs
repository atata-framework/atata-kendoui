namespace Atata.KendoUI.Tests;

public class KendoEditorTests : UITestFixture
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<EditorPage>(library).Regular;

        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set("Some value");
        control.Should.Equal("Some value");

        control.Clear();
        control.Should.BeEmpty();
    }
}
