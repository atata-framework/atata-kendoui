namespace Atata.KendoUI.Tests
{
    using _ = DateInputPage;

    [Url("dateinput")]
    public class DateInputPage : Page<_>
    {
        public KendoDateInput<_> Regular { get; private set; }

        public KendoDateInput<_> Disabled { get; private set; }

        public KendoDateInput<_> ReadOnly { get; private set; }
    }
}
