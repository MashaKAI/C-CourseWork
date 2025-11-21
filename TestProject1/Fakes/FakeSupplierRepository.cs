using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1.Fakes
{
    public class FakeSupplierRepository : ISupplierRepository
    {
        private readonly List<SupplierEntity> _data = new();

        public void Add(SupplierEntity item)
        {
            item.Id = Guid.NewGuid();
            _data.Add(item);
        }

        public void Update(SupplierEntity item)
        {
            var existing = _data.FirstOrDefault(x => x.Id == item.Id);
            if (existing != null)
            {
                existing.FirstName = item.FirstName;
                existing.LastName = item.LastName;
            }
        }

        public void Delete(Guid id)
        {
            var existing = _data.FirstOrDefault(x => x.Id == id);
            if (existing != null)
                _data.Remove(existing);
        }

        public IEnumerable<SupplierEntity> GetAll() => _data;

        public SupplierEntity GetById(Guid id) =>
            _data.FirstOrDefault(x => x.Id == id);

        public void Save()
        {
            // Fake → нічого не зберігаємо
        }
    }
}
