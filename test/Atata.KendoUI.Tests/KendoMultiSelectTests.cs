using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoMultiSelectTests : UITestFixture
    {
        private MultiSelectPage _page;

        protected override void OnSetUp()
        {
            _page = Go.To<MultiSelectPage>();
        }

        [Test]
        public void KendoMultiSelect()
        {
            var control = _page.Regular;

            control.Should.BeEnabled();
            control.IsReadOnly.Should.BeFalse();
            control.Add("Item 4");
            control.Add("Item 2");
        }

        [Test]
        public void KendoMultiSelect_Disabled()
        {
            var control = _page.Disabled;

            control.Should.BeDisabled();
            control.IsReadOnly.Should.BeFalse();
        }

        [Test]
        public void KendoMultiSelect_ReadOnly()
        {
            var control = _page.ReadOnly;

            control.Should.BeEnabled();
            control.IsReadOnly.Should.BeTrue();
        }

        [Test]
        public void KendoMultiSelect_SlowAnimation()
        {
            _page.
                SlowAnimating.Add("Item 5").
                Regular.Add("Item 3");
        }
    }
}
