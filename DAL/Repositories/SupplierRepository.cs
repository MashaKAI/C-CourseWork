using DAL.Entities;
using DAL.Exceptions;
using DAL.Interfaces;
using DAL.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly StorageContext _context;

        public SupplierRepository(StorageContext context)
        {
            _context = context;
        }

        public void Add(SupplierEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _context.Suppliers.Add(entity);
            Save();
        }

        public void Delete(Guid id)
        {
            var s = GetById(id);
            _context.Suppliers.Remove(s);
            Save();
        }

        public IEnumerable<SupplierEntity> GetAll()
        {
            return _context.Suppliers;
        }

        public SupplierEntity GetById(Guid id)
        {
            return _context.Suppliers.FirstOrDefault(x => x.Id == id)
                   ?? throw new NotFoundException($"Supplier with id {id} not found");
        }

        public void Update(SupplierEntity entity)
        {
            var existing = GetById(entity.Id);

            existing.FirstName = entity.FirstName;
            existing.LastName = entity.LastName;

            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
