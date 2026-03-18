using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetByCustomer(Guid customerId);
    }
}
