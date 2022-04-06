using System;
using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoTimePickerTests : UITestFixture
    {
        private TimePickerPage page;

        protected override void OnSetUp()
        {
            page = Go.To<TimePickerPage>();
        }

        [Test]
        public void KendoTimePicker()
        {
            var control = page.Regular;

            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();
            control.Should.BeNull();

            control.Set(TimeSpan.FromHours(15.5));
            control.Should.Equal(TimeSpan.FromHours(15.5));

            control.Set(null);
            control.Should.BeNull();

            control.Set(TimeSpan.FromHours(17));
            control.Should.Equal(TimeSpan.FromHours(17));

            control.Clear();
            control.Should.BeNull();
        }

        [Test]
        public void KendoTimePicker_Disabled()
        {
            var control = page.Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal(TimeSpan.FromHours(10.75));
        }

        [Test]
        public void KendoTimePicker_ReadOnly()
        {
            var control = page.ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(TimeSpan.FromHours(17.25));
        }
    }
}
