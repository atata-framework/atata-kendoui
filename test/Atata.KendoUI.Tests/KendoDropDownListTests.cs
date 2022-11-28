﻿namespace Atata.KendoUI.Tests;

public class KendoDropDownListTests : UITestFixture
{
    // TODO: Vue was removed. The snippet page stopped to work properly in Chrome, so Vue test removed for now.
    [TestCaseSources.JQuery]
    [TestCaseSources.React]
    [TestCaseSources.Angular]
    public void Interact(string library)
    {
        var control = GoToSnippetPage(library).Get<KendoDropDownList<SnippetPage>>();

        TestControl(control);
    }

    [TestCaseSources.JQuery]
    [Test]
    public void Disabled(string library)
    {
        var control = GoToTestPage<DropDownListPage>(library).Disabled;

        control.Should.BeDisabled();
        control.Should.Not.BeReadOnly();
        control.Should.Equal("Black");
    }

    [TestCaseSources.JQuery]
    public void ReadOnly(string library)
    {
        var control = GoToTestPage<DropDownListPage>(library).ReadOnly;

        control.Should.BeEnabled();
        control.Should.BeReadOnly();
        control.Should.Equal(DropDownListPage.ItemValue.Orange);
    }

    [TestCaseSources.JQuery]
    public void Multiple(string library) =>
        GoToTestPage<DropDownListPage>(library)
            .EnableAll()
            .Regular.Set("X-Large")
            .Disabled.Set("Grey")
            .ReadOnly.Set(DropDownListPage.ItemValue.Black)
            .Regular.Should.Equal("X-Large")
            .Disabled.Should.Equal("Grey")
            .ReadOnly.Should.Equal(DropDownListPage.ItemValue.Black);

    [TestCaseSources.JQuery]
    public void SlowAnimation(string library) =>
        GoToTestPage<DropDownListPage>(library)
            .EnableAll()
            .SlowAnimating.Set("Item 5")
            .Disabled.Set("Grey")
            .SlowAnimating.Should.Equal("Item 5")
            .Disabled.Should.Equal("Grey");

    private static void TestControl<TPage>(KendoDropDownList<TPage> control)
        where TPage : PageObject<TPage>
    {
        control.Should.BeEnabled();
        control.Should.Not.BeReadOnly();

        control.Set("Large");
        control.Should.Equal("Large");

        control.Set("Small");
        control.Should.Equal("Small");
    }
}
