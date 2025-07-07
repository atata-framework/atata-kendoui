#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = DatePickerPage;

[Url("datepicker")]
public class DatePickerPage : Page<_>
{
    public KendoDatePicker<_> Regular { get; private set; }

    [Format("dd-MM-yyyy")]
    public KendoDatePicker<_> UsingDateInput { get; private set; }

    [Format("d.M.yyyy")]
    public KendoDatePicker<_> UsingDateInputWithValue { get; private set; }

    public KendoDatePicker<_> Disabled { get; private set; }

    public KendoDatePicker<_> ReadOnly { get; private set; }
}
