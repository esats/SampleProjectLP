using System.Collections.Generic;

namespace WebApi.Models.Orders
{
    public class PagedOrderData
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<OrderData> Items { get; set; }
    }
}
