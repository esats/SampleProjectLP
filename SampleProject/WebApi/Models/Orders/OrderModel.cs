using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        [Required(ErrorMessage = "CustomerId is required")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "ProductId is required")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Total is required")]
        public decimal Total { get; set; }
    }
}
