using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationRepository;
using System.Collections.Generic;

namespace Application.Tests
{
    [TestClass]
    public class ProductsBusinessLayerTests
    {
        [TestMethod]
        public void CanGetAllProducts()
        {
            var mockRepository = new Moq.Mock<IProductRepository>();
            mockRepository.Setup(x => x.GetAllProducts()).Returns(new List<Product>()
            {
            new Product() { Id = 1, Name = "Product1", Category = "Category1", StockCount = 3, Price = 1 }});
            var BALProducts = new ApplicationBAL.ProductService(mockRepository.Object);
            Assert.AreEqual(BALProducts.GetAllProducts().Count, 1); 

        }
    }
}
