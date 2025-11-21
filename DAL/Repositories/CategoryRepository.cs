using DAL.Entities;
using DAL.Exceptions;
using DAL.Interfaces;
using DAL.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StorageContext _context;

        public CategoryRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(CategoryEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Categories.Add(entity);
            Save();
        }

        public void Delete(Guid id)
        {
            var cat = GetById(id);
            _context.Categories.Remove(cat);
            Save();
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return _context.Categories;
        }

        public CategoryEntity GetById(Guid id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id)
                   ?? throw new NotFoundException($"Category with id {id} not found");
        }

        public void Update(CategoryEntity entity)
        {
            var existing = GetById(entity.Id);
            existing.Name = entity.Name;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
