namespace Atata.KendoUI.Tests;

using _ = ComboBoxPage;

[Url("combobox")]
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
