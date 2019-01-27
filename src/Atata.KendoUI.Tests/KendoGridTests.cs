using NUnit.Framework;

namespace Atata.KendoUI.Tests
{
    public class KendoGridTests : UITestFixture
    {
        private GridPage page;

        protected override void OnSetUp()
        {
            page = Go.To<GridPage>();
        }

        [Test]
        public void KendoGrid_Basic()
        {
            var control = page.Cars;

            control.Rows.Count.Should.Equal(21);
            control.Rows.Should.Contain(x => x.CarMake == "Audi" && x.CarModel == "A4");
            control.Rows[x => x.CarMake == "Audi" && x.CarModel == "Q7"].Should.Exist();
        }
    }
}
