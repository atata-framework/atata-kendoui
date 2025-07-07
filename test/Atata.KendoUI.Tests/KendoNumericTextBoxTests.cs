namespace Atata.KendoUI.Tests;

public class KendoNumericTextBoxTests : UITestSuite
{
    [TestCaseSources.JQuery]
    [TestCaseSources.React]
    [TestCaseSources.Vue]
    public void Interact(string library)
    {
        var control = GoToSnippetPage(library).Get<KendoNumericTextBox<SnippetPage>>();

        TestControl(control);
    }

    [TestCase(TestName = $"{nameof(Interact)}(\"{KendoLibraries.Angular}\")", Explicit = true)]
    public void Interact_Angular()
    {
        var control = GoToAngularDemoPage("inputs/numerictextbox")
            .SwitchToFirstFrame()
            .Get<KendoNumericTextBox<SnippetPage>>();

        TestControl(control);
    }

    [TestCase(TestName = $"{nameof(Interact)}(\"{KendoLibraries.AspNetMvc}\")", Explicit = true)]
    public void Interact_AspNetMvc()
    {
        var control = GoToSnippetPage(KendoLibraries.AspNetMvc, "numerictextbox")
            .GetByIndex<KendoNumericTextBox<SnippetPage>>(3);

        TestControl(control);
    }

    [TestCase(TestName = $"{nameof(Interact)}(\"{KendoLibraries.AspNetCore}\")", Explicit = true)]
    public void Interact_AspNetCore()
    {
        var control = GoToSnippetPage(KendoLibraries.AspNetCore, "numerictextbox")
            .GetByIndex<KendoNumericTextBox<SnippetPage>>(3);

        TestControl(control);
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<NumericTextBoxPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Be(25.75m);
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<NumericTextBoxPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Be(0.15m);
    }

    private static void TestControl<TPage>(KendoNumericTextBox<TPage> control)
        where TPage : PageObject<TPage>
    {
        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set(125);
        control.Should.Be(125);
        control.Owner.Press(Keys.Tab);
        control.Should.Be(125);

        control.Set(98765);
        control.Should.Be(98765);

        control.Set(null);
        control.Should.BeNull();

        control.Set(9);
        control.Should.Be(9);

        control.Clear();
        control.Should.BeNull();

        control.Type("1");
        control.Type("2");
        control.Should.Be(12);
    }
}
