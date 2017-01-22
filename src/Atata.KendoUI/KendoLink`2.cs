namespace Atata.KendoUI
{
    public class KendoLink<TNavigateTo, TOwner> : KendoLink<TOwner>, INavigable<TNavigateTo, TOwner>
        where TNavigateTo : PageObject<TNavigateTo>
        where TOwner : PageObject<TOwner>
    {
    }
}
