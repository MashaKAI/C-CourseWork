using BLL.Models;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(Guid id);
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Guid id);
        IEnumerable<Supplier> SortByFirstName();
        IEnumerable<Supplier> SortByLastName();
    }
}
