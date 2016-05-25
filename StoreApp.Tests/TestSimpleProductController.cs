using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreApp.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace StoreApp.Tests
{

    [TestClass]
    public class TestSimpleProductController
    {

        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            // var entity = new Mock<StoreEntities>();

            var data = new List<product>
            {
                new product { Id= 1, Name = "Product A", Price = 100 },
                new product { Id= 2, Name = "Product B", Price = 200 },
                new product { Id= 3, Name = "Product C", Price = 300 }
            }.AsQueryable();

            var mockSet  = new Mock<DbSet<product>>();
            mockSet.As<IQueryable<product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<StoreIDBEntities>();
            mockContext.Setup(c => c.products).Returns(mockSet.Object);

            var controller = new ProductController(mockContext.Object);
            List<product> result = controller.GetAllProducts() as List<product>;
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual("Product B", result[1].Name);
            Assert.AreEqual(300, result[2].Price);

        }

    }

}
