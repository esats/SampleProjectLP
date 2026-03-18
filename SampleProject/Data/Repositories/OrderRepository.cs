using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, Order> _store = new Dictionary<Guid, Order>();

        public void Save(Order entity)
        {
            _store[entity.Id] = entity;
        }

        public void Delete(Order entity)
        {
            _store.Remove(entity.Id);
        }

        public Order Get(Guid id)
        {
            _store.TryGetValue(id, out var order);
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _store.Values;
        }

        public IEnumerable<Order> GetByCustomer(Guid customerId)
        {
            return _store.Values.Where(o => o.CustomerId == customerId);
        }
    }
}
