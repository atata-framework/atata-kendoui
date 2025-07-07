using OpenQA.Selenium;

namespace Atata.KendoUI.Tests;

public class KendoDatePickerTests : UITestFixture
{
    [TestCaseSources.JQuery]
    [TestCaseSources.React]
    [TestCaseSources.Vue]
    public void Interact(string library)
    {
        var control = GoToSnippetPage(library).Get<KendoDatePicker<SnippetPage>>();

        TestControl(control);
    }

    [TestCase(TestName = $"{nameof(Interact)}(\"{KendoLibraries.AspNetMvc}\")", Explicit = true)]
    public void Interact_AspNetMvc()
    {
        var control = GoToSnippetPage(KendoLibraries.AspNetMvc, "datepicker")
            .Get<KendoDatePicker<SnippetPage>>();

        TestControl(control);
    }

    [TestCase(TestName = $"{nameof(Interact)}(\"{KendoLibraries.AspNetCore}\")", Explicit = true)]
    public void Interact_AspNetCore()
    {
        var control = GoToSnippetPage(KendoLibraries.AspNetCore, "datepicker")
            .Get<KendoDatePicker<SnippetPage>>();

        TestControl(control);
    }

    [Test]
    [Explicit]
    public void NgKendoDatePicker()
    {
        var control = GoToAngularDemoPage("dateinputs/datepicker")
            .SwitchToFirstFrame()
            .Get<NgKendoDatePicker<SnippetPage>>();

        TestControl(control);
    }

    [TestCaseSources.JQuery]
    public void Interact_JQuery_UsingDateInput(string library)
    {
        var control = GoToTestPage<DatePickerPage>(library).UsingDateInput;

        control.Should.BeNull();

        TestControl(control);
    }

    [TestCaseSources.JQuery]
    public void Interact_JQuery_UsingDateInput_WithValue(string library)
    {
        var control = GoToTestPage<DatePickerPage>(library).UsingDateInputWithValue;

        control.Should.Be(new DateTime(1988, 11, 2));

        TestControl(control);
    }

    [TestCaseSources.JQuery]
    public void Disabled(string library)
    {
        var control = GoToTestPage<DatePickerPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Be(new DateTime(2000, 10, 10));
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<DatePickerPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Be(new DateTime(2005, 7, 20));
    }

    private static void TestControl<TPage>(KendoDatePicker<TPage> control)
        where TPage : PageObject<TPage>
    {
        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        DateTime value1 = new DateTime(2018, 7, 11);
        control.Set(value1);
        control.Should.Be(value1);

        AtataContext.Current.Driver.Perform(x => x.KeyDown(Keys.Shift).SendKeys(Keys.Tab).KeyUp(Keys.Shift));
        control.Should.Be(value1);

        DateTime value2 = new DateTime(2019, 12, 31);
        control.Set(value2);
        control.Should.Be(value2);

        DateTime value3 = new DateTime(1995, 5, 19);
        control.Set(value3);
        control.Should.Be(value3);

        control.Clear();
        control.Should.BeNull();

        control.Owner.Press(Keys.Tab);
        control.Should.BeNull();
    }
}
