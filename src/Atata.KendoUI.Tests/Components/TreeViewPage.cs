namespace Atata.KendoUI.Tests
{
    using _ = TreeViewPage;

    [Url("TreeView.html")]
    public class TreeViewPage : Page<_>
    {
        public KendoTreeView<_> Regular { get; private set; }
    }
}
