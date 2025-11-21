using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Services;
using BLL.Models;
using BLL.Exceptions;
using TestProject1.Fakes;
using System.Linq;
using System;

namespace MSTestProject
{
    [TestClass]
    public class ProductServiceTests
    {
        private ProductService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new ProductService(new FakeProductRepository());
        }

        [TestMethod]
        public void AddProduct_ShouldIncreaseCount()
        {
            int start = _service.GetAll().Count();

            _service.Add(new Product
            {
                Name = "TestProd",
                Brand = "BrandX",
                Price = 100,
                Quantity = 5
            });

            int end = _service.GetAll().Count();
            Assert.AreEqual(start + 1, end);
        }

        [TestMethod]
        public void AddProduct_InvalidPrice_ShouldThrow()
        {
            Assert.ThrowsException<ValidationException>(() =>
                _service.Add(new Product { Name = "A", Price = -1, Quantity = 1 }));
        }

        [TestMethod]
        public void SortByName_ShouldSortCorrectly()
        {
            _service.Add(new Product { Name = "B", Brand = "B", Price = 1, Quantity = 1 });
            _service.Add(new Product { Name = "A", Brand = "A", Price = 1, Quantity = 1 });

            var list = _service.SortByName().ToList();

            Assert.IsTrue(list[0].Name == "A");
        }

        [TestMethod]
        public void SearchByKeyword_ShouldReturnMatching()
        {
            _service.Add(new Product { Name = "Laptop", Brand = "Dell", Price = 100, Quantity = 1 });
            _service.Add(new Product { Name = "Mouse", Brand = "Logi", Price = 20, Quantity = 1 });

            var result = _service.SearchByKeyword("lap").ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Laptop", result[0].Name);
        }

        [TestMethod]
        public void UpdateProduct_ShouldApplyChanges()
        {
            var product = new Product
            {
                Name = "Old",
                Brand = "AB",
                Price = 1,
                Quantity = 1,
                //CategoryId = catId,
                //SupplierId = supId
            };
            _service.Add(product);

            product.Name = "New";
            _service.Update(product);

            var updated = _service.GetById(product.Id);

            Assert.IsNotNull(updated);
            Assert.AreEqual("New", updated.Name);
        }

    }
}
