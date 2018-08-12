namespace Atata.KendoUI.Tests
{
    public class KendoMultiSelectTests : UITestFixture
    {
        private MultiSelectPage page;

        protected override void OnSetUp()
        {
            page = Go.To<MultiSelectPage>();
        }
    }
}
