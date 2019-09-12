namespace Atata.KendoUI.Tests
{
    using _ = DatePickerPage;

    [Url("datepicker")]
    public class DatePickerPage : Page<_>
    {
        public KendoDatePicker<_> Regular { get; private set; }

        public KendoDatePicker<_> Disabled { get; private set; }

        public KendoDatePicker<_> ReadOnly { get; private set; }
    }
}
