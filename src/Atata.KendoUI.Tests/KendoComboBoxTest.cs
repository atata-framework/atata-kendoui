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
            page.Do(_ => _.Regular, x =>
            {
                x.Should.BeEnabled();
                x.Should.Not.BeReadOnly();
                x.Set("Some value");
                x.Should.Equal("Some value");

                string randomValue;
                x.SetRandom(out randomValue);
                x.Should.Equal(randomValue);
                x.Set(null);
                x.Should.BeNull();
            });
        }

        [Test]
        public void KendoComboBox_Disabled()
        {
            page.Do(_ => _.Disabled, x =>
            {
                x.Should.BeDisabled();
                x.Should.Not.BeReadOnly();
                x.Should.Equal("Item 1");
            });
        }

        [Test]
        public void KendoComboBox_ReadOnly()
        {
            page.Do(_ => _.ReadOnly, x =>
            {
                x.Should.BeEnabled();
                x.Should.BeReadOnly();
                x.Should.Equal(ComboBoxPage.ItemValue.Item2);
            });
        }
    }
}
