using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoComboBoxTest : AutoTest
    {
        private ComboBoxPage page;

        protected override void OnSetUp()
        {
            page = Go.To<ComboBoxPage>();
        }

        [Test]
        public void KendoComboBox()
        {
            var control = page.Regular;

            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();
            control.Set("Some value");
            control.Should.Equal("Some value");

            string randomValue;
            control.SetRandom(out randomValue);
            control.Should.Equal(randomValue);
            control.Set(null);
            control.Should.BeNull();
        }

        [Test]
        public void KendoComboBox_Disabled()
        {
            var control = page.Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal("Item 1");
        }

        [Test]
        public void KendoComboBox_ReadOnly()
        {
            var control = page.ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(ComboBoxPage.ItemValue.Item2);
        }
    }
}
