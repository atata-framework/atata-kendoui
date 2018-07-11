namespace Atata.KendoUI.Tests
{
    using _ = EditorPage;

    [Url("Editor.html")]
    public class EditorPage : Page<_>
    {
        [FindFirst]
        public KendoEditor<_> Regular { get; private set; }
    }
}
