namespace Atata.KendoUI.Tests;

using _ = NumericTextBoxPage;

[Url("numerictextbox")]
public class NumericTextBoxPage : Page<_>
{
    public KendoNumericTextBox<_> Regular { get; private set; }

    public KendoNumericTextBox<_> Disabled { get; private set; }

    public KendoNumericTextBox<_> ReadOnly { get; private set; }
}
