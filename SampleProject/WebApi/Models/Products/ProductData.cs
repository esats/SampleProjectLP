using BusinessEntities;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
            Name = product.Name;
            Description = product.Description;
            BrandName = product.BrandName;
            CategoryName = product.CategoryName;
            SKU = product.SKU;
            IsActive = product.IsActive;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string SKU { get; set; }
        public bool IsActive { get; set; }
    }
}
