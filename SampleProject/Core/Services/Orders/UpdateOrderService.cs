using System;
using BusinessEntities;
using Common;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService : IUpdateOrderService
    {
        public void Update(Order order, Guid customerId, Guid productId, decimal total)
        {
            order.SetCustomerId(customerId);
            order.SetProductId(productId);
            order.SetTotal(total);
        }

        public void UpdateStatus(Order order, OrderStatus status)
        {
            order.SetStatus(status);
        }
    }
}
