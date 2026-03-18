using System;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private Guid _customerId;
        private Guid _productId;
        private OrderStatus _status;
        private decimal _total;
        private DateTime _createdDate;

        public Guid CustomerId
        {
            get => _customerId;
            private set => _customerId = value;
        }

        public Guid ProductId
        {
            get => _productId;
            private set => _productId = value;
        }

        public OrderStatus Status
        {
            get => _status;
            private set => _status = value;
        }

        public decimal Total
        {
            get => _total;
            private set => _total = value;
        }

        public DateTime CreatedDate
        {
            get => _createdDate;
            private set => _createdDate = value;
        }

        public void SetCustomerId(Guid customerId)
        {
            _customerId = customerId;
        }

        public void SetProductId(Guid productId)
        {
            _productId = productId;
        }

        public void SetStatus(OrderStatus status)
        {
            _status = status;
        }

        public void SetTotal(decimal total)
        {
            _total = total;
        }

        public void SetCreatedDate(DateTime createdDate)
        {
            _createdDate = createdDate;
        }
    }
}
