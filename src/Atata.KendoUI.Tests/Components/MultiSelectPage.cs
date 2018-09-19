using _ = Atata.KendoUI.Tests.MultiSelectPage;

namespace Atata.KendoUI.Tests
{
    [Url("multiselect")]
    public class MultiSelectPage : Page<_>
    {
        public KendoMultiSelect<_> Regular { get; private set; }

        [FindByIndex(1)]
        public KendoMultiSelect<_> Disabled { get; private set; }

        [FindByIndex(2)]
        public KendoMultiSelect<_> ReadOnly { get; private set; }
    }
}
