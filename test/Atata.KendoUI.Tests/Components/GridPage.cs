﻿#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = GridPage;

[Url("grid")]
public class GridPage : Page<_>
{
    public KendoGrid<CarRow, _> Cars { get; private set; }

    public class CarRow : KendoGridRow<_>
    {
        public Text<_> CarMake { get; private set; }

        public Text<_> CarModel { get; private set; }

        public Content<int, _> Year { get; private set; }

        public Text<_> Category { get; private set; }

        public Text<_> AirConditioner { get; private set; }

        public ValueProvider<bool?, _> HasAirConditioner => CreateValueProvider<bool?>(
            "has air conditioner",
            () => AirConditioner == "Yes");
    }
}
