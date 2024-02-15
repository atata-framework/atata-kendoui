namespace Atata.KendoUI;

[ControlDefinition(ContainingClass = "k-treeview", ComponentTypeName = "tree view")]
[FindSettings(OuterXPath = "./ul/", TargetName = nameof(Children))]
public class KendoTreeView<TItem, TOwner> : HierarchicalControl<TItem, TOwner>
    where TItem : KendoTreeViewItem<TItem, TOwner>
    where TOwner : PageObject<TOwner>
{
}
