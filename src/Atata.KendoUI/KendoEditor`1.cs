namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-editor", ComponentTypeName = "editor")]
    [FindFirst]
    public class KendoEditor<TOwner> : FrameWrappedContentEditor<TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByClass("k-content")]
        [TraceLog]
        protected Frame<OrdinaryPage, TOwner> ContentFrame { get; set; }

        protected override Control<TOwner> GetFrameControl() => ContentFrame;
    }
}
