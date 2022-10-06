using System;

namespace Atata.KendoUI
{
    /// <summary>
    /// Represents the header cell control (<c>&lt;th&gt;</c>) of <see cref="KendoGrid{THeader, TRow, TOwner}"/>.
    /// Default search finds the first occurring <c>&lt;th&gt;</c> element.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner page object.</typeparam>
    public class KendoGridHeader<TOwner> : TableHeader<TOwner>
        where TOwner : PageObject<TOwner>
    {
        /// <summary>
        /// Gets the control that contains the text of header.
        /// </summary>
        [FindByXPath("(./*[1] | self::*)[position() = last()]")]
        public Text<TOwner> Text { get; private set; }

        /// <summary>
        /// Gets the sort order.
        /// </summary>
        public ValueProvider<KendoGridHeaderSortOrder, TOwner> SortOrder =>
            CreateValueProvider("sort order", OnGetSortOrder);

        protected virtual KendoGridHeaderSortOrder OnGetSortOrder()
        {
            string sortValue = Attributes["aria-sort"];

            return !string.IsNullOrEmpty(sortValue)
                ? (KendoGridHeaderSortOrder)Enum.Parse(typeof(KendoGridHeaderSortOrder), sortValue, ignoreCase: true)
                : KendoGridHeaderSortOrder.None;
        }

        /// <summary>
        /// Sorts in ascending order.
        /// </summary>
        /// <returns>The owner page object.</returns>
        public TOwner SortAscending() =>
            Sort(KendoGridHeaderSortOrder.Ascending);

        /// <summary>
        /// Sorts in descending order.
        /// </summary>
        /// <returns>The owner page object.</returns>
        public TOwner SortDescending() =>
            Sort(KendoGridHeaderSortOrder.Descending);

        /// <summary>
        /// Sorts using the specified order.
        /// </summary>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns>The owner page object.</returns>
        public TOwner Sort(KendoGridHeaderSortOrder sortOrder)
        {
            if (SortOrder.Value != sortOrder)
            {
                Click();

                if (SortOrder.Value != sortOrder)
                    Click();
            }

            return Owner;
        }
    }
}
