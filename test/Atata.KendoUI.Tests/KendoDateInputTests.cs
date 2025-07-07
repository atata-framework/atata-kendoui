namespace Atata.KendoUI.Tests;

public class KendoDateInputTests : UITestSuite
{
    [TestCaseSources.JQuery]
    [TestCaseSources.React]
    [TestCaseSources.Vue]
    public void Interact(string library)
    {
        var control = GoToSnippetPage(library).Get<KendoDateInput<SnippetPage>>();

        TestControl(control);
    }

    [Test]
    [Explicit]
    public void NgKendoDateInput()
    {
        var control = GoToAngularDemoPage("dateinputs/dateinput")
            .SwitchToFirstFrame()
            .Get<NgKendoDateInput<SnippetPage>>();

        TestControl(control);
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<DateInputPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Be(new DateTime(2000, 10, 10));
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<DateInputPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Be(new DateTime(2005, 7, 20));
    }

    private static void TestControl<TPage>(KendoDateInput<TPage> control)
        where TPage : PageObject<TPage>
    {
        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        DateTime value1 = new DateTime(2018, 7, 11);
        control.Set(value1);
        control.Should.Be(value1);

        WebDriverSession.Current!.Driver.Perform(x => x.KeyDown(Keys.Shift).SendKeys(Keys.Tab).KeyUp(Keys.Shift));
        control.Should.Be(value1);

        DateTime value2 = new DateTime(2019, 12, 31);
        control.Set(value2);
        control.Should.Be(value2);

        DateTime value3 = new DateTime(1995, 5, 19);
        control.Set(value3);
        control.Should.Be(value3);

        control.Clear();
        control.Should.BeNull();
    }
}
