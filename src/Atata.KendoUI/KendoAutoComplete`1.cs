namespace Atata.KendoUI
{
    /// <summary>
    /// Represents the Kendo UI auto-complete control.
    /// Default search is performed by the label.
    /// Handles any element with <c>k-autocomplete</c> class.
    /// <para>
    /// When using Kendo UI for React prefer to use <see cref="ReactKendoAutoComplete{TOwner}"/> control instead.
    /// </para>
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner page object.</typeparam>
    public class KendoAutoComplete<TOwner> : KendoAutoComplete<string, TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
