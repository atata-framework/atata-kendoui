#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = AutoCompletePage;

[Url("autocomplete")]
public class AutoCompletePage : Page<_>
{
    public KendoAutoComplete<_> Regular { get; private set; }

    public KendoAutoComplete<_> Disabled { get; private set; }

    public KendoAutoComplete<_> ReadOnly { get; private set; }
}
