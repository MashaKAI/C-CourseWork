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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repo;

        public SupplierService(ISupplierRepository repo)
        {
            _repo = repo;
        }

        public void Add(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.FirstName) || string.IsNullOrWhiteSpace(supplier.LastName))
                throw new ValidationException("Supplier first and last name cannot be empty");

            _repo.Add(supplier.ToEntity());
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _repo.GetAll().Select(s => s.ToModel());
        }

        public Supplier GetById(Guid id)
        {
            return _repo.GetById(id).ToModel();
        }

        public IEnumerable<Supplier> SortByFirstName()
        {
            return _repo.GetAll().OrderBy(s => s.FirstName).Select(s => s.ToModel());
        }

        public IEnumerable<Supplier> SortByLastName()
        {
            return _repo.GetAll().OrderBy(s => s.LastName).Select(s => s.ToModel());
        }

        public void Update(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.FirstName) || string.IsNullOrWhiteSpace(supplier.LastName))
                throw new ValidationException("Supplier first and last name cannot be empty");

            _repo.Update(supplier.ToEntity());
        }
    }
}
