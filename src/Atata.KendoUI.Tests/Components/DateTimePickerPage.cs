using _ = Atata.KendoUI.Tests.DateTimePickerPage;

namespace Atata.KendoUI.Tests
{
    [Url("DateTimePicker.html")]
    public class DateTimePickerPage : Page<_>
    {
        public KendoDateTimePicker<_> Regular { get; private set; }

        public KendoDateTimePicker<_> Disabled { get; private set; }

        public KendoDateTimePicker<_> ReadOnly { get; private set; }
    }
}
