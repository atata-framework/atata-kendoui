﻿namespace Atata.KendoUI
{
    [ControlDefinition("span", ContainingClass = "k-switch", ComponentTypeName = "switch")]
    [ControlFinding(FindTermBy.Label)]
    [IdXPathForLabel("[input[@id='{0}']]")]
    public class KendoSwitch<TOwner> : EditableField<bool, TOwner>, ICheckable<TOwner>
        where TOwner : PageObject<TOwner>
    {
        /// <summary>
        /// Gets the <see cref="DataProvider{TData, TOwner}" /> instance of the checked state value.
        /// </summary>
        public DataProvider<bool, TOwner> IsChecked => GetOrCreateDataProvider("checked", () => Value);

        /// <summary>
        /// Gets the verification provider that gives a set of verification extension methods.
        /// </summary>
        public new FieldVerificationProvider<bool, KendoSwitch<TOwner>, TOwner> Should =>
            new FieldVerificationProvider<bool, KendoSwitch<TOwner>, TOwner>(this);

        [FindFirst(Visibility = Visibility.Any)]
        [TraceLog]
        private CheckBox<TOwner> DataControl { get; set; }

        protected override bool GetValue()
        {
            return DataControl.Value;
        }

        protected override void SetValue(bool value)
        {
            if (Value != value)
                Scope.Click();
        }

        /// <summary>
        /// Checks the control. Also executes <see cref="TriggerEvents.BeforeSet" /> and <see cref="TriggerEvents.AfterSet" /> triggers.
        /// </summary>
        /// <returns>The owner page object.</returns>
        public TOwner Check()
        {
            return Set(true);
        }

        /// <summary>
        /// Unchecks the control. Also executes <see cref="TriggerEvents.BeforeSet" /> and <see cref="TriggerEvents.AfterSet" /> triggers.
        /// </summary>
        /// <returns>The owner page object.</returns>
        public TOwner Uncheck()
        {
            return Set(false);
        }

        protected override bool GetIsEnabled()
        {
            return DataControl.IsEnabled;
        }
    }
}
