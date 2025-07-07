#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = NumericTextBoxPage;

[Url("numerictextbox")]
public class NumericTextBoxPage : Page<_>
{
    public KendoNumericTextBox<_> Regular { get; private set; }

    public KendoNumericTextBox<_> Disabled { get; private set; }

    public KendoNumericTextBox<_> ReadOnly { get; private set; }
}
