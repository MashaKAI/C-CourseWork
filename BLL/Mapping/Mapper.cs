using DAL.Entities;
using BLL.Models;

namespace BLL.Mapping
{
    public static class Mapper
    {
        public static Category ToModel(this CategoryEntity entity) =>
            new Category { Id = entity.Id, Name = entity.Name };

        public static CategoryEntity ToEntity(this Category model) =>
            new CategoryEntity { Id = model.Id, Name = model.Name };

        public static Product ToModel(this ProductEntity entity) =>
            new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Brand = entity.Brand,
                Price = entity.Price,
                Quantity = entity.Quantity,
                CategoryId = entity.CategoryId,
                SupplierId = entity.SupplierId
            };

        public static ProductEntity ToEntity(this Product model) =>
            new ProductEntity
            {
                Id = model.Id,
                Name = model.Name,
                Brand = model.Brand,
                Price = model.Price,
                Quantity = model.Quantity,
                CategoryId = model.CategoryId,
                SupplierId = model.SupplierId
            };

        public static Supplier ToModel(this SupplierEntity entity) =>
            new Supplier
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };

        public static SupplierEntity ToEntity(this Supplier model) =>
            new SupplierEntity
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
    }
}
