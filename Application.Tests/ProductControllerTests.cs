using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Controllers;
using ApplicationBAL;
using System.Web.Mvc;
using System.Collections.Generic;
using Application.ViewModels;

namespace Application.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void GetProductList()
        {
            // Case when the productList is given then the productList should dispaly all the products(Count in this case)
            var mockBAL = new Moq.Mock<IProductService>();
            mockBAL.Setup(x => x.GetAllProducts()).Returns(new ProductBusinessModel[]
            {
            new ProductBusinessModel() { Id = 1, Name = "Product1", Category = "Category1", StockCount = 3, Price = 1 }});
            ProductController productController = new ProductController(mockBAL.Object);
            var result = productController.Index() as ViewResult;
            var actualProducts = result.Model as IList<ProductViewModel>;
            Assert.AreEqual(actualProducts.Count, 1);

        }


        [TestMethod]
        public void ReturnsProductDetailsView()
        {
            // Case When productdetails were given then the productDetails view should contain the given data.
            var mockBAL = new Moq.Mock<IProductService>();
            mockBAL.Setup(x => x.GetAllProducts()).Returns(new ProductBusinessModel[]
           {
            new ProductBusinessModel() { Id = 1, Name = "Product1", Category = "Category1", StockCount = 3, Price = 1 }});
            ProductController productController = new ProductController(mockBAL.Object);
            var result = productController.Index() as ViewResult;
            var products = result.Model as List<ProductViewModel>;
            Assert.IsTrue(products.Exists(x => x.Id == 1)); 
        }
    }
}
