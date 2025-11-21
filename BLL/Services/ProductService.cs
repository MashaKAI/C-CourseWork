using BLL.Interfaces;
using BLL.Models;
using BLL.Exceptions;
using DAL.Interfaces;
using BLL.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public void Add(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ValidationException("Product name cannot be empty");
            if (product.Price < 0)
                throw new ValidationException("Price cannot be negative");
            if (product.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");

            _repo.Add(product.ToEntity());
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repo.GetAll().Select(p => p.ToModel());
        }

        public Product GetById(Guid id)
        {
            return _repo.GetById(id).ToModel();
        }

        public IEnumerable<Product> SortByBrand()
        {
            return _repo.GetAll().OrderBy(p => p.Brand).Select(p => p.ToModel());
        }

        public IEnumerable<Product> SortByName()
        {
            return _repo.GetAll().OrderBy(p => p.Name).Select(p => p.ToModel());
        }

        public IEnumerable<Product> SortByPrice()
        {
            return _repo.GetAll().OrderBy(p => p.Price).Select(p => p.ToModel());
        }

        public IEnumerable<Product> SearchByKeyword(string keyword)
        {
            return _repo.GetAll()
                        .Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                    p.Brand.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                        .Select(p => p.ToModel());
        }

        public void Update(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ValidationException("Product name cannot be empty");
            if (product.Price < 0)
                throw new ValidationException("Price cannot be negative");
            if (product.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");

            _repo.Update(product.ToEntity());
        }
    }
}
