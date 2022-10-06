namespace Atata.KendoUI.Tests;

using _ = DropDownListPage;

[Url("dropdownlist")]
public class DropDownListPage : Page<_>
{
    public enum ItemValue
    {
        Black,
        Orange,
        Grey
    }

    public KendoDropDownList<_> Regular { get; private set; }

    public KendoDropDownList<_> SlowAnimating { get; private set; }

    [Term(TermMatch.StartsWith)]
    public KendoDropDownList<_> Disabled { get; private set; }

    [Term(TermMatch.StartsWith)]
    public KendoDropDownList<ItemValue, _> ReadOnly { get; private set; }

    public ButtonDelegate<_> EnableAll { get; private set; }
}
