using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoDropDownListTests : UITestFixture
    {
        private static DropDownListPage GoToTestPage()
        {
            return Go.To<DropDownListPage>();
        }

        // TODO: KendoLibrary.Vue was removed. The snippet page stopped to work properly in Chrome, so Vue test removed for now.
        ////[PlainTestCaseSource(KendoLibrary.JQuery, KendoLibrary.React, KendoLibrary.Vue, KendoLibrary.Angular)]
        [PlainTestCaseSource(KendoLibrary.JQuery, KendoLibrary.React, KendoLibrary.Angular)]
        public void KendoDropDownList(KendoLibrary library)
        {
            var control = GoToSnippetPage(library).Get<KendoDropDownList<SnippetPage>>();

            TestControl(control);
        }

        [Test]
        public void KendoDropDownList_Disabled()
        {
            var control = GoToTestPage().Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal("Black");
        }

        [Test]
        public void KendoDropDownList_ReadOnly()
        {
            var control = GoToTestPage().ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(DropDownListPage.ItemValue.Orange);
        }

        [Test]
        public void KendoDropDownList_Multiple()
        {
            GoToTestPage().
                EnableAll().
                Regular.Set("X-Large").
                Disabled.Set("Grey").
                ReadOnly.Set(DropDownListPage.ItemValue.Black).
                Regular.Should.Equal("X-Large").
                Disabled.Should.Equal("Grey").
                ReadOnly.Should.Equal(DropDownListPage.ItemValue.Black);
        }

        [Test]
        public void KendoDropDownList_SlowAnimation()
        {
            GoToTestPage().
                EnableAll().
                SlowAnimating.Set("Item 5").
                Disabled.Set("Grey").
                SlowAnimating.Should.Equal("Item 5").
                Disabled.Should.Equal("Grey");
        }

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
}
