namespace Atata.KendoUI.Tests;

using _ = DateTimePickerPage;

[Url("datetimepicker")]
public class DateTimePickerPage : Page<_>
{
    public KendoDateTimePicker<_> Regular { get; private set; }

    public KendoDateTimePicker<_> Disabled { get; private set; }

    public KendoDateTimePicker<_> ReadOnly { get; private set; }
}
