using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Atata.KendoUI.Tests
{
    public class KendoDatePickerTests : UITestFixture
    {
        private static DatePickerPage GoToTestPage()
        {
            return Go.To<DatePickerPage>();
        }

        [PlainTestCaseSource(KendoLibrary.JQuery, KendoLibrary.Vue, KendoLibrary.React)]
        public void KendoDatePicker(KendoLibrary library)
        {
            var control = GoToSnippetPage(library).Get<KendoDatePicker<SnippetPage>>();

            TestControl(control);
        }

        [TestCase(TestName = nameof(KendoDatePicker) + "(AspNetMvc)", Explicit = true)]
        public void KendoNumericTextBox_AspNetMvc()
        {
            var control = GoToSnippetPage(KendoLibrary.AspNetMvc, "datepicker").
                Get<KendoDatePicker<SnippetPage>>();

            TestControl(control);
        }

        [TestCase(TestName = nameof(KendoDatePicker) + "(AspNetCore)", Explicit = true)]
        public void KendoNumericTextBox_AspNetCore()
        {
            var control = GoToSnippetPage(KendoLibrary.AspNetCore, "datepicker").
                Get<KendoDatePicker<SnippetPage>>();

            TestControl(control);
        }

        [Test]
        [Explicit]
        public void NgKendoDatePicker()
        {
            var control = GoToAngularDemoPage("dateinputs/datepicker").
                SwitchToFirstFrame().
                Get<NgKendoDatePicker<SnippetPage>>();

            TestControl(control);
        }

        [Test]
        public void KendoDatePicker_JQuery_UsingDateInput()
        {
            var control = GoToTestPage().UsingDateInput;

            control.Should.BeNull();

            TestControl(control);
        }

        [Test]
        public void KendoDatePicker_JQuery_UsingDateInput_WithValue()
        {
            var control = GoToTestPage().UsingDateInputWithValue;

            control.Should.Equal(new DateTime(1988, 11, 2));

            TestControl(control);
        }

        [Test]
        public void KendoDatePicker_Disabled()
        {
            var control = GoToTestPage().Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal(new DateTime(2000, 10, 10));
        }

        [Test]
        public void KendoDatePicker_ReadOnly()
        {
            var control = GoToTestPage().ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(new DateTime(2005, 7, 20));
        }

        private static void TestControl<TPage>(KendoDatePicker<TPage> control)
            where TPage : PageObject<TPage>
        {
            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();

            DateTime value1 = new DateTime(2018, 7, 11);
            control.Set(value1);
            control.Should.Equal(value1);

            AtataContext.Current.Driver.Perform(x => x.KeyDown(Keys.Shift).SendKeys(Keys.Tab).KeyUp(Keys.Shift));
            control.Should.Equal(value1);

            DateTime value2 = new DateTime(2019, 12, 31);
            control.Set(value2);
            control.Should.Equal(value2);

            DateTime value3 = new DateTime(1995, 5, 19);
            control.Set(value3);
            control.Should.Equal(value3);

            control.Set(null);
            control.Should.BeNull();
        }
    }
}
