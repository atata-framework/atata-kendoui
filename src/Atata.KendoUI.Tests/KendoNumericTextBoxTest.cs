using NUnit.Framework;
using OpenQA.Selenium;

namespace Atata.KendoUI.Tests
{
    public class KendoNumericTextBoxTest : UITestFixture
    {
        private NumericTextBoxPage page;

        protected override void OnSetUp()
        {
            page = Go.To<NumericTextBoxPage>();
        }

        [Test]
        public void KendoNumericTextBox()
        {
            var control = page.Regular;

            control.Should.BeEnabled();
            control.Should.Not.BeReadOnly();
            control.Set(125);
            control.Should.Equal(125);
            page.Press(Keys.Tab);
            control.Should.Equal(125);
        }

        [Test]
        public void KendoNumericTextBox_Disabled()
        {
            var control = page.Disabled;

            control.Should.BeDisabled();
            control.Should.Not.BeReadOnly();
            control.Should.Equal(25.75m);
        }

        [Test]
        public void KendoNumericTextBox_ReadOnly()
        {
            var control = page.ReadOnly;

            control.Should.BeEnabled();
            control.Should.BeReadOnly();
            control.Should.Equal(0.15m);
        }
    }
}
