using System;
using System.Linq;

namespace Atata.KendoUI.Tests
{
    using _ = SnippetPage;

    public class SnippetPage : Page<_>
    {
        public TControl Get<TControl>(params Attribute[] attributes)
            where TControl : Control<_>
        {
            if (!attributes.Any(x => x is FindAttribute))
                attributes = new[] { new FindFirstAttribute() }.Concat(attributes).ToArray();

            var control = Controls.Create<TControl>("Test", attributes);

            control.WaitTo.Within(20).Exist();

            return control;
        }

        public _ SwitchToFirstFrame()
        {
            var frame = Controls.Create<Frame<_>>("Test");
            Driver.SwitchTo().Frame(frame.Scope);

            return this;
        }
    }
}
