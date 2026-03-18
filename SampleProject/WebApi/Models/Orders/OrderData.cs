using System;
using BusinessEntities;
using WebApi.Models;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            CustomerId = order.CustomerId;
            ProductId = order.ProductId;
            Status = order.Status;
            Total = order.Total;
            CreatedDate = order.CreatedDate;
        }

        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
