using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoCheckBoxTests : UITestFixture
    {
        private CheckBoxPage _page;

        protected override void OnSetUp()
        {
            _page = Go.To<CheckBoxPage>();
        }

        [Test]
        public void KendoCheckBox()
        {
            var control = _page.Regular;

            control.Should.Exist();
            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();
            control.Should.BeChecked();
            control.Uncheck();
            control.Should.BeUnchecked();
            control.Set(true);
            control.Should.BeChecked();
            control.Should.Equal(true);
        }

        [Test]
        public void KendoCheckBox_Disabled()
        {
            var control = _page.DisabledChecked;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal(true);
            control.Should.BeChecked();

            control = _page.DisabledUnchecked;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal(false);
            control.Should.BeUnchecked();
        }
    }
}
