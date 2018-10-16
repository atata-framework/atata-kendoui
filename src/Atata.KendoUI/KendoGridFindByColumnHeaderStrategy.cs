namespace Atata.KendoUI
{
    public class KendoGridFindByColumnHeaderStrategy : FindByColumnHeaderStrategy
    {
        public KendoGridFindByColumnHeaderStrategy()
            : base("(ancestor::*[contains(concat(' ', normalize-space(@class), ' '), ' k-grid ')])[position() = last()]//th")
        {
        }
    }
}
