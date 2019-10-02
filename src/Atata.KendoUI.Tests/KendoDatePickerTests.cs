using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Atata.KendoUI.Tests
{
    public class KendoDatePickerTests : UITestFixture
    {
        private DatePickerPage page;

        protected override void OnSetUp()
        {
            page = Go.To<DatePickerPage>();
        }

        [Test]
        public void KendoDatePicker()
        {
            var control = page.Regular;

            control.Should.BeNull();

            TestDatePicker(control);
        }

        [Test]
        public void KendoDatePicker_UsingDateInput()
        {
            var control = page.UsingDateInput;

            control.Should.BeNull();

            TestDatePicker(control);
        }

        [Test]
        public void KendoDatePicker_UsingDateInput_WithValue()
        {
            var control = page.UsingDateInputWithValue;

            control.Should.Equal(new DateTime(1988, 11, 2));

            TestDatePicker(control);
        }

        private void TestDatePicker(KendoDatePicker<DatePickerPage> control)
        {
            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();

            DateTime value1 = new DateTime(2018, 7, 11);
            control.Set(value1);
            control.Should.Equal(value1);

            page.Press(Keys.Tab);
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

        [Test]
        public void KendoDatePicker_Disabled()
        {
            var control = page.Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal(new DateTime(2000, 10, 10));
        }

        [Test]
        public void KendoDatePicker_ReadOnly()
        {
            var control = page.ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(new DateTime(2005, 7, 20));
        }
    }
}
