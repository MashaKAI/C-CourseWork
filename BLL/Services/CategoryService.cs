using BLL.Interfaces;
using BLL.Models;
using BLL.Exceptions;
using DAL.Interfaces;
using BLL.Mapping;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public void Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ValidationException("Category name cannot be empty");

            _repo.Add(category.ToEntity());
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            foreach (var entity in _repo.GetAll())
                yield return entity.ToModel();
        }

        public Category GetById(Guid id)
        {
            return _repo.GetById(id).ToModel();
        }

        public void Update(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ValidationException("Category name cannot be empty");

            _repo.Update(category.ToEntity());
        }
    }
}
