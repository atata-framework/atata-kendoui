using NUnit.Framework;
using OpenQA.Selenium;

namespace Atata.KendoUI.Tests
{
    public class KendoNumericTextBoxTests : UITestFixture
    {
        private static NumericTextBoxPage GoToTestPage()
        {
            return Go.To<NumericTextBoxPage>();
        }

        [PlainTestCaseSource(KendoLibrary.JQuery, KendoLibrary.React, KendoLibrary.Vue)]
        public void KendoNumericTextBox(KendoLibrary library)
        {
            var control = GoToSnippetPage(library).Get<KendoNumericTextBox<SnippetPage>>();

            TestControl(control);
        }

        [TestCase(TestName = nameof(KendoNumericTextBox) + "(Angular)", Explicit = true)]
        public void KendoNumericTextBox_Angular()
        {
            var control = GoToAngularDemoPage("inputs/numerictextbox").
                SwitchToFirstFrame().
                Get<KendoNumericTextBox<SnippetPage>>();

            TestControl(control);
        }

        [TestCase(TestName = nameof(KendoNumericTextBox) + "(AspNetMvc)", Explicit = true)]
        public void KendoNumericTextBox_AspNetMvc()
        {
            var control = GoToSnippetPage(KendoLibrary.AspNetMvc, "numerictextbox").
                GetByIndex<KendoNumericTextBox<SnippetPage>>(3);

            TestControl(control);
        }

        [TestCase(TestName = nameof(KendoNumericTextBox) + "(AspNetCore)", Explicit = true)]
        public void KendoNumericTextBox_AspNetCore()
        {
            var control = GoToSnippetPage(KendoLibrary.AspNetCore, "numerictextbox").
                GetByIndex<KendoNumericTextBox<SnippetPage>>(3);

            TestControl(control);
        }

        [Test]
        public void KendoNumericTextBox_Disabled()
        {
            var control = GoToTestPage().Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal(25.75m);
        }

        [Test]
        public void KendoNumericTextBox_ReadOnly()
        {
            var control = GoToTestPage().ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(0.15m);
        }

        private void TestControl<TPage>(KendoNumericTextBox<TPage> control)
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
        }
    }
}
