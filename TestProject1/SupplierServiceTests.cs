using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Services;
using BLL.Models;
using BLL.Exceptions;
using TestProject1.Fakes;
using System.Linq;

namespace MSTestProject
{
    [TestClass]
    public class SupplierServiceTests
    {
        private SupplierService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new SupplierService(new FakeSupplierRepository());
        }

        [TestMethod]
        public void AddSupplier_ShouldIncreaseCount()
        {
            int before = _service.GetAll().Count();

            _service.Add(new Supplier
            {
                FirstName = "Ivan",
                LastName = "Ivanov"
            });

            int after = _service.GetAll().Count();
            Assert.AreEqual(before + 1, after);
        }

        [TestMethod]
        public void AddSupplier_Invalid_ShouldThrow()
        {
            Assert.ThrowsException<ValidationException>(() =>
                _service.Add(new Supplier { FirstName = "", LastName = "" }));
        }

        [TestMethod]
        public void SortByFirstName_ShouldSort()
        {
            _service.Add(new Supplier { FirstName = "Boris", LastName = "L" });
            _service.Add(new Supplier { FirstName = "Andriy", LastName = "A" });

            var list = _service.SortByFirstName().ToList();

            Assert.IsTrue(list[0].FirstName == "Andriy");
        }

        [TestMethod]
        public void UpdateSupplier_ShouldApplyChanges()
        {
            var supplier = new Supplier { FirstName = "Old", LastName = "Last" };
            _service.Add(supplier);

            supplier.FirstName = "New";
            _service.Update(supplier);

            var updated = _service.GetById(supplier.Id);

            Assert.IsNotNull(updated);
            Assert.AreEqual("New", updated.FirstName);
        }

    }
}
