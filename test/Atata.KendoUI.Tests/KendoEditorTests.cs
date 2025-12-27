namespace Atata.KendoUI.Tests;

public sealed class KendoEditorTests : UITestSuite
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<EditorPage>(library).Regular;

        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set("Some value");
        control.Should.Be("Some value");

        control.Clear();
        control.Should.BeEmpty();
    }
}
