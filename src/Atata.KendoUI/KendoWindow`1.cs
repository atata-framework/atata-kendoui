namespace Atata.KendoUI
{
    [PageObjectDefinition("div", ContainingClass = "k-window", ComponentTypeName = "window", IgnoreNameEndings = "PopupWindow,Window,Popup")]
    [WindowTitleElementDefinition(ContainingClass = "k-window-title")]
    public abstract class KendoWindow<TKendoWindowContent, TOwner> : PopupWindow<TOwner>
        where TOwner : KendoWindow<TKendoWindowContent, TOwner>
        where TKendoWindowContent : Control<TOwner>
    {
        protected KendoWindow(params string[] windowTitleValues)
            : base(windowTitleValues)
        {
        }

        [FindByClass("k-window-actions")]
        public ControlList<Link<TOwner>, TOwner> Actions { get; set; }

        [FindByClass("k-window-content k-content")]
        public TKendoWindowContent WindowContent { get; set; }
    }
}
