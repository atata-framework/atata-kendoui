namespace Atata.KendoUI.Tests
{
    using _ = TreeViewPage;

    [Url("treeview")]
    public class TreeViewPage : Page<_>
    {
        [FindByIndex(0)]
        public KendoTreeView<_> Regular { get; private set; }

        [FindByIndex(1)]
        public KendoTreeView<_> SlowAnimating { get; private set; }

        [FindById]
        public KendoTreeView<_> WithCheckboxes { get; private set; }

        [FindById]
        public KendoTreeView<CustomKendoTreeViewItem, _> WithCustomTemplate { get; private set; }

        [Format("{0} !", TargetName = nameof(Text))]
        [ValueXPath("/span/strong")]
        public class CustomKendoTreeViewItem : KendoTreeViewItem<CustomKendoTreeViewItem, _>
        {
            [FindByClass("k-i-close-outline")]
            public Link<_> Remove { get; private set; }
        }
    }
}
