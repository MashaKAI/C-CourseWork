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
    public class CategoryServiceTests
    {
        private CategoryService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new CategoryService(new FakeCategoryRepository());
        }

        [TestMethod]
        public void AddCategory_ShouldIncreaseCount()
        {
            int start = _service.GetAll().Count();
            _service.Add(new Category { Name = "Test" });
            int end = _service.GetAll().Count();

            Assert.AreEqual(start + 1, end);
        }

        [TestMethod]
        public void AddCategory_EmptyName_ShouldThrow()
        {
            Assert.ThrowsException<ValidationException>(() =>
                _service.Add(new Category { Name = "" }));
        }

        [TestMethod]
        public void DeleteCategory_ShouldDecreaseCount()
        {
            var category = new Category { Name = "ABC" };
            _service.Add(category);

            int before = _service.GetAll().Count();

            _service.Delete(category.Id);
            int after = _service.GetAll().Count();

            Assert.AreEqual(before - 1, after);
        }


        [TestMethod]
        public void UpdateCategory_ShouldUpdateName()
        {
            var c = new Category { Name = "Old" };
            _service.Add(c);

            c.Name = "New";
            _service.Update(c);

            var updated = _service.GetById(c.Id);
            Assert.AreEqual("New", updated.Name);
        }

        [TestMethod]
        public void UpdateCategory_InvalidName_ShouldThrow()
        {
            var c = new Category { Name = "Valid" };
            _service.Add(c);

            c.Name = " ";
            Assert.ThrowsException<ValidationException>(() =>
                _service.Update(c));
        }

        [TestMethod]
        public void GetAll_ShouldReturnAll()
        {
            _service.Add(new Category { Name = "A" });
            _service.Add(new Category { Name = "B" });

            var list = _service.GetAll().ToList();
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void GetById_ShouldReturnCorrectCategory()
        {
            var category = new Category { Name = "FindMe" };
            _service.Add(category);

            var found = _service.GetById(category.Id);

            Assert.IsNotNull(found);
            Assert.AreEqual("FindMe", found.Name);
        }
    }
}
