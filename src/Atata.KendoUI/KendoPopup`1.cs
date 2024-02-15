namespace Atata.KendoUI;

[ControlDefinition(ContainingClass = "k-popup", ComponentTypeName = "popup", IgnoreNameEndings = "Popup")]
public class KendoPopup<TOwner> : Control<TOwner>
    where TOwner : PageObject<TOwner>
{
    /// <summary>
    /// Gets the default animation waiting options.
    /// Timeout is 5 seconds.
    /// Interval is 0.1 seconds.
    /// </summary>
    public static RetryOptions DefaultAnimationWaitingOptions { get; } = new RetryOptions
    {
        Interval = TimeSpan.FromSeconds(.1),
        Timeout = TimeSpan.FromSeconds(5)
    };

    public TOwner WaitUntilOpen(RetryOptions waitingOptions = null) =>
        this.WaitForCssTransitionEnd("open", waitingOptions ?? DefaultAnimationWaitingOptions);

    public TOwner WaitUntilClosed(RetryOptions waitingOptions = null) =>
        this.WaitForCssTransitionEnd("close", waitingOptions ?? DefaultAnimationWaitingOptions, SearchOptions.SafelyAtOnce());
}
