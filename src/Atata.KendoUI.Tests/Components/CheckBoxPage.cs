namespace Atata.KendoUI.Tests
{
    using _ = CheckBoxPage;

    [Url("CheckBox.html")]
    public class CheckBoxPage : Page<_>
    {
        [FindById]
        public KendoCheckBox<_> Regular { get; private set; }

        [FindById]
        public KendoCheckBox<_> DisabledChecked { get; private set; }

        [FindById]
        public KendoCheckBox<_> DisabledUnchecked { get; private set; }
    }
}
