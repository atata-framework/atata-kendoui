using System.Linq;

namespace Atata.KendoUI
{
    [ControlDefinition("a", ContainingClass = "k-link", ComponentTypeName = "link", IgnoreNameEndings = "Button,Link")]
    public class KendoLink<TOwner> : Link<TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override bool GetIsEnabled() =>
            !Attributes.Class.Value.Contains(KendoClass.Disabled);
    }
}
