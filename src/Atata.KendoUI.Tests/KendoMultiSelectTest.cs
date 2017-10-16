namespace Atata.KendoUI.Tests
{
    public class KendoMultiSelectTest : UITestFixture
    {
        private MultiSelectPage page;

        protected override void OnSetUp()
        {
            page = Go.To<MultiSelectPage>();
        }
    }
}
