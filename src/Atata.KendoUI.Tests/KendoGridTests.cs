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

            control.Rows.Count.Should.Equal(12);
            control.Rows.Should.Contain(x => x.CarMake == "Audi" && x.CarModel == "A4");
            control.Rows[x => x.CarMake == "Honda" && x.CarModel == "Accord"].Should.Exist();
            control.Rows[x => x.CarMake == "Volvo" && x.Year == 2010].HasAirConditioner.Should.BeTrue();
            control.Rows[2].CarModel.Should.Equal("535d");
        }
    }
}
