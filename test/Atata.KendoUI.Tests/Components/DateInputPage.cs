#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = DateInputPage;

[Url("dateinput")]
public sealed class DateInputPage : Page<_>
{
    public KendoDateInput<_> Regular { get; private set; }

    public KendoDateInput<_> Disabled { get; private set; }

    public KendoDateInput<_> ReadOnly { get; private set; }
}
