using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }

        public string SKU { get; set; }

        public bool IsActive { get; set; }
    }
}
