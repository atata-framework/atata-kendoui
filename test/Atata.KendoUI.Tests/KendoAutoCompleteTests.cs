namespace Atata.KendoUI.Tests;

public class KendoAutoCompleteTests : UITestFixture
{
    private static AutoCompletePage GoToTestPage() =>
        Go.To<AutoCompletePage>();

    [PlainTestCaseSource(KendoLibrary.JQuery, KendoLibrary.Vue, KendoLibrary.Angular)]
    public void Interact(KendoLibrary library)
    {
        var control = GoToSnippetPage(library)
            .Get<KendoAutoComplete<SnippetPage>>();

        TestControl(control);
    }

    [Test]
    public void ReactKendoAutoComplete()
    {
        var control = GoToSnippetPage(KendoLibrary.React)
            .Get<ReactKendoAutoComplete<SnippetPage>>();

        TestControl(control);
    }

    [Test]
    public void Disabled()
    {
        var control = GoToTestPage().Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Equal("Spain");
    }

    [Test]
    public void ReadOnly()
    {
        var control = GoToTestPage().ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Equal("Norway");
    }

    private static void TestControl<TPage>(KendoAutoComplete<string, TPage> control)
        where TPage : PageObject<TPage>
    {
        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set("France");
        control.Should.Equal("France");

        control.Set("Germany, Austria");
        control.Should.Equal("Germany, Austria");

        control.Clear();
        control.Should.BeEmpty();
    }
}
