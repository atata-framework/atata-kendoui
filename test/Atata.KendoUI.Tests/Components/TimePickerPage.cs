namespace Atata.KendoUI.Tests;

using _ = TimePickerPage;

[Url("timepicker")]
public class TimePickerPage : Page<_>
{
    public KendoTimePicker<_> Regular { get; private set; }

    public KendoTimePicker<_> Disabled { get; private set; }

    public KendoTimePicker<_> ReadOnly { get; private set; }
}
