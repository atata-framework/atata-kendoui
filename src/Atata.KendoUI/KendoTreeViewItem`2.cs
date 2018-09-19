using System;
using System.Collections.Generic;
using System.Linq;

namespace Atata.KendoUI
{
    [ControlDefinition("li", ContainingClass = "k-item", ComponentTypeName = "item", Visibility = Visibility.Any)]
    [FindSettings(OuterXPath = "./ul/", TargetName = nameof(Children))]
    [FindSettings(OuterXPath = ".//", TargetName = nameof(Descendants))]
    [FindSettings(OuterXPath = "./*[1]//", Visibility = Visibility.Any)]
    public class KendoTreeViewItem<TItem, TOwner> : HierarchicalItem<TItem, TOwner>
        where TItem : KendoTreeViewItem<TItem, TOwner>
        where TOwner : PageObject<TOwner>
    {
        /// <summary>
        /// Gets the default animation waiting options.
        /// Timeout is 5 seconds.
        /// Interval is 0.1 seconds.
        /// </summary>
        public static RetryOptions DefaultAnimationWaitingOptions { get; } = new RetryOptions
        {
            Interval = TimeSpan.FromSeconds(.1),
            Timeout = TimeSpan.FromSeconds(7)
        };

        /// <summary>
        /// Gets or sets the waiting options of expand animation.
        /// Uses <see cref="DefaultAnimationWaitingOptions"/> as default value.
        /// </summary>
        protected RetryOptions ExpandAnimationWaitingOptions { get; set; } = DefaultAnimationWaitingOptions;

        /// <summary>
        /// Gets or sets the waiting options of collapse animation.
        /// Uses <see cref="DefaultAnimationWaitingOptions"/> as default value.
        /// </summary>
        protected RetryOptions CollapseAnimationWaitingOptions { get; set; } = DefaultAnimationWaitingOptions;

        [FindFirst]
        protected CheckBox<TOwner> CheckBox { get; private set; }

        [FindByClass("k-checkbox-wrapper")]
        [InvokeMethod(nameof(EnsureThatVisible), TriggerEvents.BeforeClickOrHoverOrFocus)]
        protected Control<TOwner> CheckBoxWrapper { get; private set; }

        /// <summary>
        /// Gets the text control.
        /// Finds control by "k-in" class.
        /// More specific/deep path to find text element can be set via <see cref="ValueXPathAttribute"/> applied to custom class inherited from <see cref="KendoTreeViewItem{TItem, TOwner}"/>, for example:
        /// <c>[ValueXPath("/span[1]/strong")]</c>.
        /// Format can be applied using <c>[Format("CUSTOM{0}FORMAT", TargetName = nameof(Text))]</c> attribute applied to custom inherited class.
        /// It is also possible to override <see cref="GetTextAttributes"/> method to add/replace specific attributes.
        /// </summary>
        [ContentSource(ContentSource.TextContent)]
        [InvokeMethod(nameof(EnsureThatVisible), TriggerEvents.BeforeClickOrHoverOrFocus)]
        public Text<TOwner> Text => Controls.Resolve<Text<TOwner>>(nameof(Text), GetTextAttributes);

        [FindByClass("k-icon")]
        [InvokeMethod(nameof(EnsureThatVisible), TriggerEvents.BeforeClickOrHoverOrFocus)]
        public Control<TOwner> ToggleIcon { get; protected set; }

        [FindByClass("k-group", OuterXPath = null)]
        protected Control<TOwner> ChildrenGroup { get; private set; }

        public DataProvider<bool, TOwner> IsExpanded =>
            GetOrCreateDataProvider("expanded state", GetIsExpanded);

        public DataProvider<bool, TOwner> IsChecked =>
            GetOrCreateDataProvider("checked state", GetIsChecked);

        public DataProvider<bool, TOwner> IsSelected =>
            GetOrCreateDataProvider("selected state", GetIsSelected);

        public DataProvider<bool, TOwner> IsFocused =>
            GetOrCreateDataProvider("focused state", GetIsFocused);

        protected string TextXPath =>
            Metadata.Get<ValueXPathAttribute>(AttributeLevels.DeclaredAndComponent)?.XPath;

        protected virtual IEnumerable<Attribute> GetTextAttributes()
        {
            yield return new FindByXPathAttribute($"*[contains(concat(' ', normalize-space(@class), ' '), ' k-in ')]{TextXPath}");
        }

        protected virtual bool GetIsExpanded()
        {
            return ToggleIcon.Attributes.Class.Value.Contains(KendoClass.Icon.Collapse);
        }

        protected virtual bool GetIsChecked()
        {
            return CheckBox.IsChecked;
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
                OnToggle(true);

            return Owner;
        }

        public TOwner Collapse()
        {
            if (IsExpanded)
                OnToggle(false);

            return Owner;
        }

        public TOwner Toggle()
        {
            bool expand = !IsExpanded;

            OnToggle(expand);

            return Owner;
        }

        protected virtual void OnToggle(bool expand)
        {
            ToggleIcon.Click();

            if (expand)
                ChildrenGroup.WaitForCssTransitionEnd("expand", ExpandAnimationWaitingOptions);
            else
                ChildrenGroup.WaitForCssTransitionEnd("collapse", CollapseAnimationWaitingOptions);
        }

        protected void EnsureThatVisible()
        {
            if (!IsVisible)
                Parent.Expand();
        }

        public TOwner Check()
        {
            if (!IsChecked)
                CheckBoxWrapper.Click();

            return Owner;
        }

        public TOwner Uncheck()
        {
            if (IsChecked)
                CheckBoxWrapper.Click();

            return Owner;
        }
    }
}
