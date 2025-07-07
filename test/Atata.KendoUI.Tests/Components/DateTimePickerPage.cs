#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = DateTimePickerPage;

[Url("datetimepicker")]
public class DateTimePickerPage : Page<_>
{
    public KendoDateTimePicker<_> Regular { get; private set; }

    public KendoDateTimePicker<_> Disabled { get; private set; }

    public KendoDateTimePicker<_> ReadOnly { get; private set; }
}
