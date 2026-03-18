using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Core.Services.Orders;
using Core.Services.Products;
using Core.Services.Users;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;
        private readonly IGetProductService _getProductService;
        private readonly IGetUserService _getUserService;

        public OrderController(
            ICreateOrderService createOrderService,
            IDeleteOrderService deleteOrderService,
            IGetOrderService getOrderService,
            IUpdateOrderService updateOrderService,
            IGetProductService getProductService,
            IGetUserService getUserService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
            _getProductService = getProductService;
            _getUserService = getUserService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationFailed();
            }

            var existing = _getOrderService.GetOrder(orderId);
            if (existing != null)
            {
                return AlreadyExists();
            }

            var product = _getProductService.GetProduct(model.ProductId);
            if (product == null)
            {
                return DoesNotExistWithMessage("No product found. You Should run product create query on postman");
            }

            var customer = _getUserService.GetUser(model.CustomerId);
            if (customer == null)
            {
                return DoesNotExistWithMessage("No customer found. You Should run initialize sample data queries on postman");
            }

            var order = _createOrderService.Create(orderId, model.CustomerId, model.ProductId, model.Total);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationFailed();
            }

            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            var product = _getProductService.GetProduct(model.ProductId);
            if (product == null)
            {
                return DoesNotExistWithMessage("No product found. You Should run product create query on postman");
            }

            var customer = _getUserService.GetUser(model.CustomerId);
            if (customer == null)
            {
                return DoesNotExistWithMessage("No customer found. You Should run initialize sample data queries on postman");
            }

            _updateOrderService.Update(order, model.CustomerId, model.ProductId, model.Total);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/status")]
        [HttpPost]
        public HttpResponseMessage UpdateOrderStatus(Guid orderId, [FromBody] OrderStatusModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationFailed();
            }

            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            _updateOrderService.UpdateStatus(order, model.Status);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            _deleteOrderService.Delete(order);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            return Found(new OrderData(order));
        }

        [Route("filter")]
        [HttpGet]
        public HttpResponseMessage FilterOrders([FromUri] Guid customerId, [FromUri] int page = 1, [FromUri] int pageSize = 10)
        {
            var customer = _getUserService.GetUser(customerId);
            if (customer == null)
            {
                return DoesNotExistWithMessage("No customer found. You Should run initialize sample data queries on postman");
            }

            var orders = _getOrderService.GetOrdersByCustomer(customerId).ToList();
            var totalCount = orders.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            var items = orders.Skip((page - 1) * pageSize).Take(pageSize).Select(o => new OrderData(o));

            return Found(new PagedOrderData
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = items
            });
        }
    }
}
