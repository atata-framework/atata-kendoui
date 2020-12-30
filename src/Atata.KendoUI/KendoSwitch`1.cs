using System;
using System.Linq;

namespace Atata.KendoUI
{
    [ControlDefinition(ContainingClass = "k-switch", ComponentTypeName = "switch")]
    [FindByLabel]
    [IdXPathForLabel("[input[@id='{0}']]")]
    public class KendoSwitch<TOwner> : EditableField<bool, TOwner>, ICheckable<TOwner>
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
            Timeout = TimeSpan.FromSeconds(5)
        };

        [Name("Handle")]
        [FindByClass("k-switch-handle")]
        [TraceLog]
        protected Control<TOwner> SwitchHandle { get; private set; }

        /// <summary>
        /// Gets the <see cref="DataProvider{TData, TOwner}" /> instance of the checked state value.
        /// </summary>
        public DataProvider<bool, TOwner> IsChecked => GetOrCreateDataProvider("checked state", () => Value);

        /// <summary>
        /// Gets the verification provider that gives a set of verification extension methods.
        /// </summary>
        public new FieldVerificationProvider<bool, KendoSwitch<TOwner>, TOwner> Should =>
            new FieldVerificationProvider<bool, KendoSwitch<TOwner>, TOwner>(this);

        protected override bool GetValue()
        {
            return Attributes.Class.Value.Contains("k-switch-on");
        }

        protected override void SetValue(bool value)
        {
            if (Value != value)
                Scope.ClickWithLogging();
        }

        /// <summary>
        /// Checks the control.
        /// Also executes <see cref="TriggerEvents.BeforeSet" /> and <see cref="TriggerEvents.AfterSet" /> triggers.
        /// </summary>
        /// <returns>The owner page object.</returns>
        public TOwner Check()
        {
            return Set(true);
        }

        /// <summary>
        /// Unchecks the control.
        /// Also executes <see cref="TriggerEvents.BeforeSet" /> and <see cref="TriggerEvents.AfterSet" /> triggers.
        /// </summary>
        /// <returns>The owner page object.</returns>
        public TOwner Uncheck()
        {
            return Set(false);
        }

        /// <summary>
        /// Toggles the state of the control.
        /// </summary>
        /// <returns>The owner page object.</returns>
        public TOwner Toggle()
        {
            return Set(!Value);
        }

        protected override bool GetIsReadOnly()
        {
            return Attributes.GetValue<bool?>("aria-readonly") == true;
        }

        protected override bool GetIsEnabled()
        {
            return !Attributes.Class.Value.Contains(KendoClass.Disabled);
        }
    }
}
