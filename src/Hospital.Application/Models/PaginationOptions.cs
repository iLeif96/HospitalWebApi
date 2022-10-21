using Hospital.Domain.Enum;

namespace Hospital.Application.Models
{
    public class PaginationOptions
    {
        public Page Page { get; set; }
        public SortOrder SortOrder { get; set; }
        public string? OrderColumnName { get; set; }

        public PaginationOptions(int page, string order, string orderColumnName)
        {
            SetPageParameters(page, order, orderColumnName);
        }

        public PaginationOptions(Page page, SortOrder sortOrder, string orderColumnName)
        {
            Page = page;
            SortOrder = sortOrder;
            OrderColumnName = orderColumnName;
        }

        private void SetPageParameters(int page, string order, string orderColumnName)
        {
            SortOrder = SortOrder.NONE;

            if (string.Compare(order, "asc", true) == 0)
            {
                SortOrder = SortOrder.ASC;
            }
            else if (string.Compare(order, "desc", true) == 0)
            {
                SortOrder = SortOrder.DESC;
            }

            if (page < 0)
            {
                page = 0;
            }

            Page = new Page(page);

            OrderColumnName = orderColumnName;
        }
    }
}
