using DAL.Entities;
using DAL.Exceptions;
using DAL.Interfaces;
using DAL.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StorageContext _context;

        public ProductRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(ProductEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Products.Add(entity);
            Save();
        }

        public void Delete(Guid id)
        {
            var p = GetById(id);
            _context.Products.Remove(p);
            Save();
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _context.Products;
        }

        public ProductEntity GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id)
                   ?? throw new NotFoundException($"Product with id {id} not found");
        }

        public void Update(ProductEntity entity)
        {
            var existing = GetById(entity.Id);

            existing.Name = entity.Name;
            existing.Brand = entity.Brand;
            existing.Price = entity.Price;
            existing.Quantity = entity.Quantity;
            existing.CategoryId = entity.CategoryId;
            existing.SupplierId = entity.SupplierId;

            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
