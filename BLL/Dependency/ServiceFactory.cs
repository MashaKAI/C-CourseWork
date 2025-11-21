using BLL.Interfaces;
using BLL.Services;
using DAL.Repositories;
using DAL.Storage;

namespace BLL.Dependency
{
    public static class ServiceFactory
    {
        private static readonly StorageContext _context = new StorageContext("Data");

        public static ICategoryService CreateCategoryService()
        {
            return new CategoryService(new CategoryRepository(_context));
        }

        public static IProductService CreateProductService()
        {
            return new ProductService(new ProductRepository(_context));
        }

        public static ISupplierService CreateSupplierService()
        {
            return new SupplierService(new SupplierRepository(_context));
        }
    }
}
