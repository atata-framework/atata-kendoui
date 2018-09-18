namespace Atata.KendoUI.Tests
{
    using _ = RadioButtonPage;

    [Url("radiobutton")]
    public class RadioButtonPage : Page<_>
    {
        [FindById]
        public KendoRadioButton<_> Regular { get; private set; }

        [FindById]
        public KendoRadioButton<_> DisabledChecked { get; private set; }

        [FindById]
        public KendoRadioButton<_> DisabledUnchecked { get; private set; }
    }
}
