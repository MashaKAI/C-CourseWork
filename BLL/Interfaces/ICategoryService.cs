using BLL.Models;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(Guid id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Guid id);
    }
}
