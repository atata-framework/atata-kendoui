namespace Atata.KendoUI.Tests;

public class KendoEditorTests : UITestFixture
{
    private EditorPage _page;

    protected override void OnSetUp() =>
        _page = Go.To<EditorPage>();

    [Test]
    public void Interact()
    {
        var control = _page.Regular;

        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set("Some value");
        control.Should.Equal("Some value");

        control.Clear();
        control.Should.BeEmpty();
    }
}
