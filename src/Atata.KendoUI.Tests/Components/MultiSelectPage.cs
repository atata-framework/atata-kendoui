using _ = Atata.KendoUI.Tests.MultiSelectPage;

namespace Atata.KendoUI.Tests
{
    [Url("MultiSelect.html")]
    public class MultiSelectPage : Page<_>
    {
        public KendoMultiSelect<_> Regular { get; private set; }

        public KendoMultiSelect<_> Disabled { get; private set; }

        public KendoMultiSelect<_> ReadOnly { get; private set; }
    }
}
