using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoDropDownListTest : AutoTest
    {
        private DropDownListPage page;

        protected override void OnSetUp()
        {
            page = Go.To<DropDownListPage>();
        }

        [Test]
        public void KendoDropDownList()
        {
            var control = page.Regular;

            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();
            control.Set("Item 20");
            control.Should.Equal("Item 20");
            control.Set("Item 7");
            control.Should.Equal("Item 7");
        }

        [Test]
        public void KendoDropDownList_Disabled()
        {
            var control = page.Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal("Black");
        }

        [Test]
        public void KendoDropDownList_ReadOnly()
        {
            var control = page.ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(DropDownListPage.ItemValue.Orange);
        }

        [Test]
        public void KendoDropDownList_Multiple()
        {
            page.
                EnableAll().
                Regular.Set("Item 19").
                Disabled.Set("Grey").
                ReadOnly.Set(DropDownListPage.ItemValue.Black).
                Regular.Should.Equal("Item 19").
                Disabled.Should.Equal("Grey").
                ReadOnly.Should.Equal(DropDownListPage.ItemValue.Black);
        }

        [Test]
        public void KendoDropDownList_SlowClosing()
        {
            page.
                EnableAll().
                SlowClosing.Set("Item 5").
                Disabled.Set("Grey").
                SlowClosing.Should.Equal("Item 5").
                Disabled.Should.Equal("Grey");
        }
    }
}
