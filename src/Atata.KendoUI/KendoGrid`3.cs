namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-grid", ComponentTypeName = "grid", IgnoreNameEndings = "DataGrid,Grid,Table")]
    public class KendoGrid<THeader, TRow, TOwner> : Table<THeader, TRow, TOwner>
        where THeader : TableHeader<TOwner>
        where TRow : KendoGridRow<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
