using System;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private string _name;
        private string _description;
        private string _brandName;
        private string _categoryName;
        private string _sku;
        private bool _isActive;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public string BrandName
        {
            get => _brandName;
            private set => _brandName = value;
        }

        public string CategoryName
        {
            get => _categoryName;
            private set => _categoryName = value;
        }

        public string SKU
        {
            get => _sku;
            private set => _sku = value;
        }

        public bool IsActive
        {
            get => _isActive;
            private set => _isActive = value;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            _name = name;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public void SetBrandName(string brandName)
        {
            _brandName = brandName;
        }

        public void SetCategoryName(string categoryName)
        {
            _categoryName = categoryName;
        }

        public void SetSKU(string sku)
        {
            _sku = sku;
        }

        public void SetIsActive(bool isActive)
        {
            _isActive = isActive;
        }
    }
}
