namespace Atata.KendoUI.Tests
{
    public class KendoMultiSelectTest : AutoTest
    {
        private MultiSelectPage page;

        protected override void OnSetUp()
        {
            page = Go.To<MultiSelectPage>();
        }
    }
}
