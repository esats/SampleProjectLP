using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<Guid, Product> _store = new Dictionary<Guid, Product>();

        public void Save(Product entity)
        {
            _store[entity.Id] = entity;
        }

        public void Delete(Product entity)
        {
            _store.Remove(entity.Id);
        }

        public Product Get(Guid id)
        {
            _store.TryGetValue(id, out var product);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _store.Values;
        }

        public IEnumerable<Product> GetFiltered(string brandName, string categoryName)
        {
            var products = _store.Values.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(brandName))
                products = products.Where(p => p.BrandName == brandName);

            if (!string.IsNullOrWhiteSpace(categoryName))
                products = products.Where(p => p.CategoryName == categoryName);

            return products;
        }
    }
}
