using BusinessEntities;

namespace Core.Services.Products
{
    public interface IUpdateProductService
    {
        void Update(Product product, string name, string description, string brandName, string categoryName, string sku, bool isActive);
    }
}
