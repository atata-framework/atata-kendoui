using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoMultiSelectTests : UITestFixture
    {
        private MultiSelectPage page;

        protected override void OnSetUp()
        {
            page = Go.To<MultiSelectPage>();
        }

        [Test]
        public void KendoMultiSelect()
        {
            var control = page.Regular;

            control.Should.BeEnabled();
            control.IsReadOnly.Should.BeFalse();
            control.Add("Item 4");
            control.Add("Item 2");
        }

        [Test]
        public void KendoMultiSelect_Disabled()
        {
            var control = page.Disabled;

            control.Should.BeDisabled();
            control.IsReadOnly.Should.BeFalse();
        }

        [Test]
        public void KendoMultiSelect_ReadOnly()
        {
            var control = page.ReadOnly;

            control.Should.BeEnabled();
            control.IsReadOnly.Should.BeTrue();
        }

        [Test]
        public void KendoMultiSelect_SlowAnimation()
        {
            page.
                SlowAnimating.Add("Item 5").
                Regular.Add("Item 3");
        }
    }
}
