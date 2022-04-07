using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoSwitchTests : UITestFixture
    {
        private SwitchPage _page;

        protected override void OnSetUp()
        {
            _page = Go.To<SwitchPage>();
        }

        [Test]
        public void KendoSwitch()
        {
            var control = _page.Regular;

            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();
            control.Should.BeFalse();
            control.Should.Not.BeChecked();

            control.Set(true);
            control.Should.BeTrue();
            control.Should.BeChecked();

            control.Uncheck();
            control.Should.BeFalse();
            control.IsChecked.Should.BeFalse();

            control.Check();
            control.Should.BeTrue();
            control.IsChecked.Should.BeTrue();

            control.Toggle();
            control.Toggle();
            control.Toggle();

            control.Should.BeFalse();
        }

        [Test]
        public void KendoSwitch_Disabled()
        {
            var control = _page.Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.BeTrue();
            control.Should.BeChecked();
        }

        [Test]
        public void KendoSwitch_FindByLabel()
        {
            var control = _page.FindsByLabel;

            control.Should.BeEnabled();
            control.Should.BeFalse();

            control.Check();
            control.Should.BeTrue();
        }
    }
}
