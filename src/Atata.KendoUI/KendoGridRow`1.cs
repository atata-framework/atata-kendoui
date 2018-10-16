namespace Atata.KendoUI
{
    [ControlDefinition("tr[parent::table or parent::tbody][not(@class) or @class!='k-grouping-row']", ComponentTypeName = "row")]
    [FindSettings(Strategy = typeof(KendoGridFindByColumnHeaderStrategy), TargetAttributeType = typeof(FindByColumnHeaderAttribute), TargetAnyType = true)]
    public class KendoGridRow<TOwner> : TableRow<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
