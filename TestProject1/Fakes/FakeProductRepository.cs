using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly List<ProductEntity> _data = new();

        public void Add(ProductEntity item)
        {
            item.Id = Guid.NewGuid();
            _data.Add(item);
        }

        public void Update(ProductEntity item)
        {
            var existing = _data.FirstOrDefault(x => x.Id == item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Brand = item.Brand;
                existing.Price = item.Price;
                existing.Quantity = item.Quantity;
                existing.CategoryId = item.CategoryId;
                existing.SupplierId = item.SupplierId;
            }
        }

        public void Delete(Guid id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item != null)
                _data.Remove(item);
        }

        public IEnumerable<ProductEntity> GetAll() => _data;

        public ProductEntity GetById(Guid id) =>
            _data.FirstOrDefault(x => x.Id == id);

        public void Save()
        {
            // Нічого не робимо
        }
    }
}
