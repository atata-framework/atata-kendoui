namespace Atata.KendoUI.Tests
{
    using _ = Atata.KendoUI.Tests.WindowPage;

    [Url("Window.html")]
    public class WindowPage : Page<_>
    {
        [FindById("undo")]
        public Clickable<KendoWindowPage, _> Undo { get; set; }
    }
}

namespace Atata.KendoUI.Tests
{
    using _ = Atata.KendoUI.Tests.KendoWindowPage;

    [WindowTitle("About Alvar Aalto")]
    public class KendoWindowPage : KendoWindow<KendoWindowPage.WindowContentPage, _>
    {
        public class WindowContentPage : Control<_>
        {
            [FindById]
            public Text<_> Text { get; set; }
        }
    }
}
