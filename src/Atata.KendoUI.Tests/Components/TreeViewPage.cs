namespace Atata.KendoUI.Tests
{
    using _ = TreeViewPage;

    [Url("TreeView.html")]
    public class TreeViewPage : Page<_>
    {
        [FindByIndex(0)]
        public KendoTreeView<_> Regular { get; private set; }

        [FindByIndex(1)]
        public KendoTreeView<_> SlowAnimating { get; private set; }

        [FindById]
        public KendoTreeView<_> WithCheckboxes { get; private set; }
    }
}
