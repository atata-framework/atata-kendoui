using System;
using System.Linq;
using OpenQA.Selenium;

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
                WaitForToggleAnimationEnd("expand", ExpandAnimationWaitingOptions);
            else
                WaitForToggleAnimationEnd("collapse", CollapseAnimationWaitingOptions);
        }

        protected void EnsureThatVisible()
        {
            if (!IsVisible)
                Parent.Expand();
        }

        protected void WaitForToggleAnimationEnd(string animationName, RetryOptions waitingOptions)
        {
            Log.Start($"Wait for {animationName} animation completion", LogLevel.Trace);

            ChildrenGroup.Scope.Try().Until(
                IsNoTransition,
                waitingOptions);

            Log.EndSection();
        }

        private bool IsNoTransition(IWebElement element)
        {
            string transitionDuration = element.GetCssValue("transitionDuration");

            return transitionDuration == null
                || !decimal.TryParse(transitionDuration.TrimEnd('m', 's'), out decimal transitionTime)
                || transitionTime == 0;
        }
    }
}
