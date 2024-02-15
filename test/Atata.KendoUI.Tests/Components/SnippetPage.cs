namespace Atata.KendoUI.Tests;

using _ = SnippetPage;

public class SnippetPage : Page<_>
{
    public TControl Get<TControl>(params Attribute[] attributes)
        where TControl : Control<_>
    {
        if (!attributes.Any(x => x is FindAttribute))
            attributes = [new FindFirstAttribute(), .. attributes];

        var control = Find<TControl>("Test", attributes);

        control.WaitTo.WithinSeconds(45).BePresent();

        return control;
    }

    public TControl GetByIndex<TControl>(int index, params Attribute[] attributes)
        where TControl : Control<_>
    {
        attributes = [new FindByIndexAttribute(index), .. attributes];

        return Get<TControl>(attributes);
    }

    public _ SwitchToFirstFrame()
    {
        var frame = Find<Frame<_>>("Test");
        Driver.SwitchTo().Frame(frame.Scope);

        return this;
    }

    public _ WaitAndClickRunButton()
    {
        var runButton = Find<Button<_>>(
            "Run this project",
            new FindByContentAttribute(TermCase.None));

        runButton.WaitTo.WithinSeconds(30).BeVisible();
        runButton.Click();

        return this;
    }

    public _ WaitAndClickAcceptAndCloseButton()
    {
        var acceptButton = Find<Button<_>>(
            "Accept and Close",
            new FindByIdAttribute("onetrust-accept-btn-handler"));

        acceptButton.WaitTo.WithinSeconds(30).BeVisible();
        acceptButton.Click();

        return this;
    }
}
