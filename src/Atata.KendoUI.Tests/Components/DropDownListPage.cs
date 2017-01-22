using _ = Atata.KendoUI.Tests.DropDownListPage;

namespace Atata.KendoUI.Tests
{
    [Url("DropDownList.html")]
    public class DropDownListPage : Page<_>
    {
        public enum ItemValue
        {
            Black,
            Orange,
            Grey
        }

        public KendoDropDownList<_> Regular { get; private set; }

        [Term(TermMatch.StartsWith)]
        public KendoDropDownList<_> Disabled { get; private set; }

        [Term(TermMatch.StartsWith)]
        public KendoDropDownList<ItemValue, _> ReadOnly { get; private set; }
    }
}
