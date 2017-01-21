using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoNumericTextBoxTest : AutoTest
    {
        private NumericTextBoxPage page;

        protected override void OnSetUp()
        {
            page = Go.To<NumericTextBoxPage>();
        }

        [Test]
        public void KendoNumericTextBox()
        {
            page.Do(_ => _.Regular, x =>
            {
                x.Should.BeEnabled();
                x.Should.Not.BeReadOnly();
                x.Set(125);
                x.Should.Equal(125);
            });
        }

        [Test]
        public void KendoNumericTextBox_Disabled()
        {
            page.Do(_ => _.Disabled, x =>
            {
                x.Should.BeDisabled();
                x.Should.Not.BeReadOnly();
                x.Should.Equal(25.75m);
            });
        }

        [Test]
        public void KendoNumericTextBox_ReadOnly()
        {
            page.Do(_ => _.ReadOnly, x =>
            {
                x.Should.BeEnabled();
                x.Should.BeReadOnly();
                x.Should.Equal(0.15m);
            });
        }
    }
}
