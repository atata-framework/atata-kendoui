namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-editor", ComponentTypeName = "editor")]
    [ControlFinding(typeof(FindFirstAttribute))]
    public class KendoEditor<TOwner> : EditableField<string, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByClass("k-content")]
        [TraceLog]
        protected Frame<OrdinaryPage, TOwner> ContentFrame { get; set; }

        protected override string GetValue()
        {
            string content = null;
            ContentFrame.DoWithin(x => content = x.Content);
            return ConvertStringToValue(content);
        }

        protected override void SetValue(string value)
        {
            string valueAsString = ConvertValueToString(value);
            ContentFrame.DoWithin(x => x.Scope.FillInWith(valueAsString));
        }
    }
}
