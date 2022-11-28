using System;

namespace Atata.KendoUI
{
    public static class KendoClass
    {
        public const string Disabled = "k-disabled";

        public const string StateDisabled = "k-state-disabled";

        public const string Selected = "k-selected";

        public const string StateSelected = "k-state-selected";

        public const string Focus = "k-focus";

        [Obsolete("Use Focus or StateFocused instead.")] // Obsolete since v2.2.0.
        public const string Focused = Focus;

        public const string StateFocused = "k-state-focused";

        public const string FormattedValue = "k-formatted-value";

        public static class Icon
        {
            public const string Expand = "k-i-expand";

            public const string Collapse = "k-i-collapse";
        }
    }
}
