using System;
using NUnit.Framework;

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

            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();
            control.Should.BeNull();

            DateTime value = new DateTime(2018, 7, 11);
            control.Set(value);
            control.Should.Equal(value);

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
