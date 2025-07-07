#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Atata.KendoUI.Tests;

using _ = EditorPage;

[Url("editor")]
public class EditorPage : Page<_>
{
    [FindFirst]
    public KendoEditor<_> Regular { get; private set; }
}
