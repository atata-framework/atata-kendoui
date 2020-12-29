namespace Atata.KendoUI
{
    /// <summary>
    /// Represents the Kendo UI auto-complete control for React.
    /// Default search is performed by the label.
    /// Handles any element with <c>k-autocomplete</c> class.
    /// </summary>
    /// <typeparam name="T">The type of the control's data.</typeparam>
    /// <typeparam name="TOwner">The type of the owner page object.</typeparam>
    public class ReactKendoAutoComplete<T, TOwner> : KendoAutoComplete<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override void SetValue(T value)
        {
            OnClear();

            string valueAsString = ConvertValueToStringUsingSetFormat(value);

            if (!string.IsNullOrEmpty(valueAsString))
            {
                AssociatedInput.Scope.SendKeys(valueAsString);
            }
        }

        protected override void OnClear()
        {
            AssociatedInput.Script.SetValueAndDispatchChangeEvent(string.Empty);
        }
    }
}
