#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = ComboBoxPage;

[Url("combobox")]
public sealed class ComboBoxPage : Page<_>
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
