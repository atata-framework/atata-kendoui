namespace Atata.KendoUI.Tests
{
    using _ = SwitchPage;

    [Url("Switch.html")]
    public class SwitchPage : Page<_>
    {
        public KendoSwitch<_> Regular { get; private set; }

        [FindByXPath("[input[@id='disabled']]")]
        public KendoSwitch<_> Disabled { get; private set; }

        [FindByLabel]
        public KendoSwitch<_> FindsByLabel { get; private set; }
    }
}
