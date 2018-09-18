using _ = Atata.KendoUI.Tests.NumericTextBoxPage;

namespace Atata.KendoUI.Tests
{
    [Url("numerictextbox")]
    public class NumericTextBoxPage : Page<_>
    {
        public KendoNumericTextBox<_> Regular { get; private set; }

        public KendoNumericTextBox<_> Disabled { get; private set; }

        public KendoNumericTextBox<_> ReadOnly { get; private set; }
    }
}
