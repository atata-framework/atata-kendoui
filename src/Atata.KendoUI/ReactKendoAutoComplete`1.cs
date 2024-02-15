namespace Atata.KendoUI;

/// <summary>
/// Represents the Kendo UI auto-complete control for React.
/// Default search is performed by the label.
/// Handles any element with <c>k-autocomplete</c> class.
/// </summary>
/// <typeparam name="TOwner">The type of the owner page object.</typeparam>
public class ReactKendoAutoComplete<TOwner> : ReactKendoAutoComplete<string, TOwner>
    where TOwner : PageObject<TOwner>
{
}
