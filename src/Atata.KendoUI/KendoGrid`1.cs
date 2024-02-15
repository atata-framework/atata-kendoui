namespace Atata.KendoUI;

public class KendoGrid<TOwner> : KendoGrid<KendoGridHeader<TOwner>, KendoGridRow<TOwner>, TOwner>
    where TOwner : PageObject<TOwner>
{
}
