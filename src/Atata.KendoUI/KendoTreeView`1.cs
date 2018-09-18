namespace Atata.KendoUI
{
    public class KendoTreeView<TOwner> : KendoTreeView<KendoTreeViewItem<TOwner>, TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
