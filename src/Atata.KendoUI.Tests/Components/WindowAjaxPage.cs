namespace Atata.KendoUI.Tests
{
    using _ = Atata.KendoUI.Tests.WindowAjaxPage;

    [Url("WindowAjax.html")]
    public class WindowAjaxPage : Page<_>
    {
        [FindById("undo")]
        public Clickable<KendoWindowAjaxPage, _> Undo { get; set; }
    }
}

namespace Atata.KendoUI.Tests
{
    using _ = Atata.KendoUI.Tests.KendoWindowAjaxPage;

    [WindowTitle("About Alvar Aalto")]
    public class KendoWindowAjaxPage : KendoWindow<KendoWindowAjaxPage.WindowContentPage, _>
    {
        public class WindowContentPage : Control<_>
        {
            [FindById]
            public Text<_> Text { get; set; }
        }
    }
}
