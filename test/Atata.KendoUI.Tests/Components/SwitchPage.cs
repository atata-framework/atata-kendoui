#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = SwitchPage;

[Url("switch")]
public sealed class SwitchPage : Page<_>
{
    public KendoSwitch<_> Regular { get; private set; }

    [FindByXPath("[input[@id='disabled']]")]
    public KendoSwitch<_> Disabled { get; private set; }

    [FindByLabel]
    public KendoSwitch<_> FindsByLabel { get; private set; }
}
