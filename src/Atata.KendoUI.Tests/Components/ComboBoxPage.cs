using _ = Atata.KendoUI.Tests.ComboBoxPage;

namespace Atata.KendoUI.Tests
{
    [Url("ComboBox.html")]
    public class ComboBoxPage : Page<_>
    {
        public enum ItemValue
        {
            Item1,
            Item2
        }

        public KendoComboBox<_> Regular { get; private set; }

        public KendoComboBox<_> Disabled { get; private set; }

        public KendoComboBox<ItemValue, _> ReadOnly { get; private set; }
    }
}
