namespace Atata.KendoUI.Tests;

public class KendoAutoCompleteTests : UITestSuite
{
    [TestCaseSources.JQuery]
    [TestCaseSources.Vue]
    [TestCaseSources.Angular]
    public void Interact(string library)
    {
        var control = GoToSnippetPage(library)
            .Get<KendoAutoComplete<SnippetPage>>();

        TestControl(control);
    }

    [Test]
    public void ReactKendoAutoComplete()
    {
        var control = GoToSnippetPage(KendoLibraries.React)
            .Get<ReactKendoAutoComplete<SnippetPage>>();

        TestControl(control);
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<AutoCompletePage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Be("Spain");
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<AutoCompletePage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Be("Norway");
    }

    private static void TestControl<TPage>(KendoAutoComplete<string, TPage> control)
        where TPage : PageObject<TPage>
    {
        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set("France");
        control.Should.Be("France");

        control.Set("Germany, Austria");
        control.Should.Be("Germany, Austria");

        control.Clear();
        control.Should.BeEmpty();
    }
}
