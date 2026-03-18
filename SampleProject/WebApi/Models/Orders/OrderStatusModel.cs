using System.ComponentModel.DataAnnotations;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderStatusModel
    {
        [Required(ErrorMessage = "Status is required")]
        public OrderStatus Status { get; set; }
    }
}
