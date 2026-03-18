using BusinessEntities;
using Common;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(Product product, string name, string description, string brandName, string categoryName, string sku, bool isActive)
        {
            product.SetName(name);
            product.SetDescription(description);
            product.SetBrandName(brandName);
            product.SetCategoryName(categoryName);
            product.SetSKU(sku);
            product.SetIsActive(isActive);
        }
    }
}
