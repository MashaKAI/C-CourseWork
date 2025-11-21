using BLL.Models;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);

        IEnumerable<Product> SortByName();
        IEnumerable<Product> SortByBrand();
        IEnumerable<Product> SortByPrice();
        IEnumerable<Product> SearchByKeyword(string keyword);
    }
}
