﻿namespace Atata.KendoUI.Tests;

public class KendoGridTests : UITestFixture
{
    private GridPage _page;

    protected override void OnSetUp() =>
        _page = Go.To<GridPage>();

    [Test]
    public void Interact()
    {
        var control = _page.Cars;

        control.Rows.Count.Should.Equal(12);
        control.Rows.Should.Contain(x => x.CarMake == "Audi" && x.CarModel == "A4");
        control.Rows[x => x.CarMake == "Honda" && x.CarModel == "Accord"].Should.Exist();
        control.Rows[x => x.CarMake == "Volvo" && x.Year == 2010].HasAirConditioner.Should.BeTrue();
        control.Rows[2].CarModel.Should.Equal("535d");
    }

    [Test]
    public void Sort()
    {
        var control = _page.Cars;

        var header1 = control.Headers[x => x.Text == "Car Make"];
        var header2 = control.Headers[x => x.Text == "Car Model"];

        header1.SortOrder.Should.Equal(KendoGridHeaderSortOrder.None);
        header1.SortAscending();
        header1.SortOrder.Should.Equal(KendoGridHeaderSortOrder.Ascending);

        header2.SortDescending();
        header1.SortOrder.Should.Equal(KendoGridHeaderSortOrder.None);
        header2.SortOrder.Should.Equal(KendoGridHeaderSortOrder.Descending);

        header2.Sort(KendoGridHeaderSortOrder.None);
        header2.SortOrder.Should.Equal(KendoGridHeaderSortOrder.None);
    }
}
