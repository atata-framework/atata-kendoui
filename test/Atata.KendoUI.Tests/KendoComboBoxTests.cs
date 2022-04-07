using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoComboBoxTests : UITestFixture
    {
        private ComboBoxPage _page;

        protected override void OnSetUp()
        {
            _page = Go.To<ComboBoxPage>();
        }

        [Test]
        public void KendoComboBox()
        {
            var control = _page.Regular;

            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();

            control.Set("Some value");
            control.Should.Equal("Some value");

            control.SetRandom(out string randomValue);
            control.Should.Equal(randomValue);

            control.Clear();
            control.Should.BeEmpty();
        }

        [Test]
        public void KendoComboBox_Disabled()
        {
            var control = _page.Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal("Item 1");
        }

        [Test]
        public void KendoComboBox_ReadOnly()
        {
            var control = _page.ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(ComboBoxPage.ItemValue.Item2);
        }
    }
}
