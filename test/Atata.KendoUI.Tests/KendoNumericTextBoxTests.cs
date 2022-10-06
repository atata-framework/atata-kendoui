using OpenQA.Selenium;

namespace Atata.KendoUI.Tests;

public class KendoNumericTextBoxTests : UITestFixture
{
    private static NumericTextBoxPage GoToTestPage() =>
        Go.To<NumericTextBoxPage>();

    [PlainTestCaseSource(KendoLibrary.JQuery, KendoLibrary.React, KendoLibrary.Vue)]
    public void Interact(KendoLibrary library)
    {
        var control = GoToSnippetPage(library).Get<KendoNumericTextBox<SnippetPage>>();

        TestControl(control);
    }

    [TestCase(TestName = nameof(Interact) + "(Angular)", Explicit = true)]
    public void Interact_Angular()
    {
        var control = GoToAngularDemoPage("inputs/numerictextbox")
            .SwitchToFirstFrame()
            .Get<KendoNumericTextBox<SnippetPage>>();

        TestControl(control);
    }

    [TestCase(TestName = nameof(Interact) + "(AspNetMvc)", Explicit = true)]
    public void Interact_AspNetMvc()
    {
        var control = GoToSnippetPage(KendoLibrary.AspNetMvc, "numerictextbox")
            .GetByIndex<KendoNumericTextBox<SnippetPage>>(3);

        TestControl(control);
    }

    [TestCase(TestName = nameof(Interact) + "(AspNetCore)", Explicit = true)]
    public void Interact_AspNetCore()
    {
        var control = GoToSnippetPage(KendoLibrary.AspNetCore, "numerictextbox")
            .GetByIndex<KendoNumericTextBox<SnippetPage>>(3);

        TestControl(control);
    }

    [Test]
    public void Disabled()
    {
        var control = GoToTestPage().Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Equal(25.75m);
    }

    [Test]
    public void ReadOnly()
    {
        var control = GoToTestPage().ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Equal(0.15m);
    }

    private static void TestControl<TPage>(KendoNumericTextBox<TPage> control)
        where TPage : PageObject<TPage>
    {
        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set(125);
        control.Should.Equal(125);
        control.Owner.Press(Keys.Tab);
        control.Should.Equal(125);

        control.Set(98765);
        control.Should.Equal(98765);

        control.Set(null);
        control.Should.BeNull();

        control.Set(9);
        control.Should.Equal(9);

        control.Clear();
        control.Should.BeNull();

        control.Type("1");
        control.Type("2");
        control.Should.Equal(12);
    }
}
