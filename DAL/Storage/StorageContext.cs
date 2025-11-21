using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Storage
{
    public class StorageContext
    {
        private readonly JsonStorage _categoryStorage;
        private readonly JsonStorage _productStorage;
        private readonly JsonStorage _supplierStorage;

        public List<CategoryEntity> Categories { get; set; }
        public List<ProductEntity> Products { get; set; }
        public List<SupplierEntity> Suppliers { get; set; }

        public StorageContext(string baseFolder)
        {
            _categoryStorage = new JsonStorage(Path.Combine(baseFolder, "categories.json"));
            _productStorage = new JsonStorage(Path.Combine(baseFolder, "products.json"));
            _supplierStorage = new JsonStorage(Path.Combine(baseFolder, "suppliers.json"));

            Categories = _categoryStorage.Load<CategoryEntity>();
            Products = _productStorage.Load<ProductEntity>();
            Suppliers = _supplierStorage.Load<SupplierEntity>();
        }

        public void SaveChanges()
        {
            _categoryStorage.Save(Categories);
            _productStorage.Save(Products);
            _supplierStorage.Save(Suppliers);
        }
    }
}
