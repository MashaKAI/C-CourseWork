using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1.Fakes
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private readonly List<CategoryEntity> _data = new();

        public void Add(CategoryEntity item)
        {
            item.Id = Guid.NewGuid();
            _data.Add(item);
        }

        public void Update(CategoryEntity item)
        {
            var existing = _data.FirstOrDefault(x => x.Id == item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
            }
        }

        public void Delete(Guid id)
        {
            var existing = _data.FirstOrDefault(x => x.Id == id);
            if (existing != null)
                _data.Remove(existing);
        }

        public IEnumerable<CategoryEntity> GetAll() => _data;

        public CategoryEntity GetById(Guid id) =>
            _data.FirstOrDefault(x => x.Id == id);

        public void Save()
        {
            // Fake repo → нічого не робимо
        }
    }
}
