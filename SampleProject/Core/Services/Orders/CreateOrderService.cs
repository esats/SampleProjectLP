using System;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IUpdateOrderService _updateOrderService;

        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrderRepository orderRepository, IUpdateOrderService updateOrderService)
        {
            _orderFactory = orderFactory;
            _orderRepository = orderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(Guid id, Guid customerId, Guid productId, decimal total)
        {
            var order = _orderFactory.Create(id);
            order.SetStatus(OrderStatus.Ordered);
            order.SetCreatedDate(DateTime.UtcNow);
            _updateOrderService.Update(order, customerId, productId, total);
            _orderRepository.Save(order);
            return order;
        }
    }
}
