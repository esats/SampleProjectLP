using System;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        void Update(Order order, Guid customerId, Guid productId, decimal total);
        void UpdateStatus(Order order, OrderStatus status);
    }
}
