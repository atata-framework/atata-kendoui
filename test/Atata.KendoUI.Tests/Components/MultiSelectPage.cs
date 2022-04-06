namespace Atata.KendoUI.Tests
{
    using _ = MultiSelectPage;

    [Url("multiselect")]
    public class MultiSelectPage : Page<_>
    {
        public KendoMultiSelect<_> SlowAnimating { get; private set; }

        public KendoMultiSelect<_> Regular { get; private set; }

        [FindByIndex(2)]
        public KendoMultiSelect<_> Disabled { get; private set; }

        [FindByIndex(3)]
        public KendoMultiSelect<_> ReadOnly { get; private set; }
    }
}
