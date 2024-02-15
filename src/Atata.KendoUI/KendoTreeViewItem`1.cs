namespace Atata.KendoUI;

public class KendoTreeViewItem<TOwner> : KendoTreeViewItem<KendoTreeViewItem<TOwner>, TOwner>
    where TOwner : PageObject<TOwner>
{
}
