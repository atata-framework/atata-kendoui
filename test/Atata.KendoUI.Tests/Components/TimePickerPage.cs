#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = TimePickerPage;

[Url("timepicker")]
public class TimePickerPage : Page<_>
{
    public KendoTimePicker<_> Regular { get; private set; }

    public KendoTimePicker<_> Disabled { get; private set; }

    public KendoTimePicker<_> ReadOnly { get; private set; }
}
