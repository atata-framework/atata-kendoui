namespace Atata.KendoUI.Tests
{
    using _ = Atata.KendoUI.Tests.WindowIFramePage;

    [Url("WindowIFrame.html")]
    public class WindowIFramePage : Page<_>
    {
        protected override void OnInit()
        {
            base.OnInit();
        }

        [FindById("undo")]
        public Clickable<KendoWindowIFramePage, _> Undo { get; set; }
    }
}

namespace Atata.KendoUI.Tests
{
    using _ = Atata.KendoUI.Tests.KendoWindowIFramePage;

    [WindowTitle("About Alvar Aalto")]
    public class KendoWindowIFramePage : KendoWindow<KendoWindowIFramePage.WindowContentPage, _>
    {
        [IFrame(".//iframe[@title='About Alvar Aalto']", AppliesTo = TriggerScope.Children, Priority = TriggerPriority.Highest)]
        public class WindowContentPage : Control<_>
        {
            [FindById(ScopeSource = ScopeSource.Page)]
            public Text<_> Text { get; set; }
        }
    }
}
