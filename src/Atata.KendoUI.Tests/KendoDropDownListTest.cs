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
    }
}
