using _ = Atata.KendoUI.Tests.TimePickerPage;

namespace Atata.KendoUI.Tests
{
    [Url("TimePicker.html")]
    public class TimePickerPage : Page<_>
    {
        public KendoTimePicker<_> Regular { get; private set; }

        public KendoTimePicker<_> Disabled { get; private set; }

        public KendoTimePicker<_> ReadOnly { get; private set; }
    }
}
