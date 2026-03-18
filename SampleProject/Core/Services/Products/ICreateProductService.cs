using System;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface ICreateProductService
    {
        Product Create(Guid id, string name, string description, string brandName, string categoryName, string sku, bool isActive);
    }
}
