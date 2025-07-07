namespace Atata.KendoUI.Tests;

public class KendoGridTests : UITestFixture
{
    [TestCaseSources.JQuery]
    public void Interact(string library)
    {
        var control = GoToTestPage<GridPage>(library).Cars;

        control.Rows.Count.Should.Be(12);
        control.Rows.Should.Contain(x => x.CarMake == "Audi" && x.CarModel == "A4");
        control.Rows[x => x.CarMake == "Honda" && x.CarModel == "Accord"].Should.BePresent();
        control.Rows[x => x.CarMake == "Volvo" && x.Year == 2010].HasAirConditioner.Should.BeTrue();
        control.Rows[2].CarModel.Should.Be("535d");
    }

    [TestCaseSources.JQuery]
    public void Sort(string library)
    {
        var control = GoToTestPage<GridPage>(library).Cars;

        var header1 = control.Headers[x => x.Text == "Car Make"];
        var header2 = control.Headers[x => x.Text == "Car Model"];

        header1.SortOrder.Should.Be(KendoGridHeaderSortOrder.None);
        header1.SortAscending();
        header1.SortOrder.Should.Be(KendoGridHeaderSortOrder.Ascending);

        header2.SortDescending();
        header1.SortOrder.Should.Be(KendoGridHeaderSortOrder.None);
        header2.SortOrder.Should.Be(KendoGridHeaderSortOrder.Descending);

        header2.Sort(KendoGridHeaderSortOrder.None);
        header2.SortOrder.Should.Be(KendoGridHeaderSortOrder.None);
    }
}
