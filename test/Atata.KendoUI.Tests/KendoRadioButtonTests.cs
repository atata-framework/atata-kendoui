using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoRadioButtonTests : UITestFixture
    {
        private RadioButtonPage page;

        protected override void OnSetUp()
        {
            page = Go.To<RadioButtonPage>();
        }

        [Test]
        public void KendoRadioButton()
        {
            var control = page.Regular;

            control.Should.Exist();
            control.Should.BeEnabled();
            control.Should.Not.BeChecked();
            control.Check();
            control.Should.BeChecked();
            control.Should.Equal(true);
        }

        [Test]
        public void KendoRadioButton_Disabled()
        {
            var control = page.DisabledChecked;

            control.Should.BeDisabled();
            control.Should.Equal(true);
            control.Should.BeChecked();

            control = page.DisabledUnchecked;

            control.Should.BeDisabled();
            control.Should.Equal(false);
            control.Should.BeUnchecked();
        }
    }
}
