﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Atata.KendoUI.Tests
{
    public class KendoDateInputTests : UITestFixture
    {
        private static DateInputPage GoToTestPage()
        {
            return Go.To<DateInputPage>();
        }

        [PlainTestCaseSource(KendoLibrary.JQuery, KendoLibrary.React, KendoLibrary.Vue)]
        public void KendoDateInput(KendoLibrary library)
        {
            var control = GoToSnippetPage(library).Get<KendoDateInput<SnippetPage>>();

            TestControl(control);
        }

        [Test]
        [Explicit]
        public void NgKendoDateInput()
        {
            var control = GoToAngularDemoPage("dateinputs/dateinput").
                SwitchToFirstFrame().
                Get<NgKendoDateInput<SnippetPage>>();

            TestControl(control);
        }

        [Test]
        public void KendoDateInput_Disabled()
        {
            var control = GoToTestPage().Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal(new DateTime(2000, 10, 10));
        }

        [Test]
        public void KendoDateInput_ReadOnly()
        {
            var control = GoToTestPage().ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(new DateTime(2005, 7, 20));
        }

        private static void TestControl<TPage>(KendoDateInput<TPage> control)
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

            control.Clear();
            control.Should.BeNull();
        }
    }
}
