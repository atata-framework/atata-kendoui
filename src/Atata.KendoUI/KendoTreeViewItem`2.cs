using System.Linq;

namespace Atata.KendoUI
{
    [ControlDefinition("li", ContainingClass = "k-item", ComponentTypeName = "item", Visibility = Visibility.Any)]
    [FindSettings(OuterXPath = "./ul/", TargetName = nameof(Children))]
    [FindSettings(OuterXPath = ".//", TargetName = nameof(Descendants))]
    [FindSettings(OuterXPath = "./*[1]/", Visibility = Visibility.Any)]
    public class KendoTreeViewItem<TItem, TOwner> : HierarchicalItem<TItem, TOwner>
        where TItem : KendoTreeViewItem<TItem, TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByClass("k-in")]
        [ContentSource(ContentSource.TextContent)]
        [InvokeMethod(nameof(EnsureThatVisible), TriggerEvents.BeforeClickOrHoverOrFocus)]
        public Text<TOwner> Text { get; protected set; }

        [FindByClass("k-icon")]
        [InvokeMethod(nameof(EnsureThatVisible), TriggerEvents.BeforeClickOrHoverOrFocus)]
        public Control<TOwner> ToggleIcon { get; protected set; }

        [FindByClass("k-group", OuterXPath = null)]
        public Control<TOwner> ChildrenGroup { get; private set; }

        public DataProvider<bool, TOwner> IsExpanded =>
            GetOrCreateDataProvider("expanded state", GetIsExpanded);

        public DataProvider<bool, TOwner> IsSelected =>
            GetOrCreateDataProvider("selected state", GetIsSelected);

        public DataProvider<bool, TOwner> IsFocused =>
            GetOrCreateDataProvider("focused state", GetIsFocused);

        protected virtual bool GetIsExpanded()
        {
            return ToggleIcon.Attributes.Class.Value.Contains(KendoClass.Icon.Collapse);
        }

        protected virtual bool GetIsSelected()
        {
            return Text.Attributes.Class.Value.Contains(KendoClass.Selected);
        }

        protected virtual bool GetIsFocused()
        {
            return Text.Attributes.Class.Value.Contains(KendoClass.Focused);
        }

        protected override bool GetIsEnabled()
        {
            return !Text.Attributes.Class.Value.Contains(KendoClass.Disabled);
        }

        protected override void OnClick()
        {
            Text.Click();
        }

        protected override void OnDoubleClick()
        {
            Text.DoubleClick();
        }

        protected override void OnRightClick()
        {
            Text.RightClick();
        }

        public TOwner Select()
        {
            return Text.Click();
        }

        public TOwner Expand()
        {
            if (!IsExpanded)
                Toggle();

            return Owner;
        }

        public TOwner Collapse()
        {
            if (IsExpanded)
                Toggle();

            return Owner;
        }

        public TOwner Toggle()
        {
            return ToggleIcon.Click();
        }

        protected void EnsureThatVisible()
        {
            if (!IsVisible)
                Parent.Expand();
        }
    }
}
