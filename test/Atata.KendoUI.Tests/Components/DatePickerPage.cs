namespace Atata.KendoUI.Tests
{
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
}
