using AutoMapper;
using ApplicationBAL;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Implementing the constructore injection for productService Interface.
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var productList = _productService.GetAllProducts();
            var mapper = GetMapper<ProductBusinessModel, ProductViewModel>();
            var productViewModelList = productList.Select(p => mapper.Map<ProductBusinessModel, ProductViewModel>(p)).ToList();
            return View(productViewModelList);
        }

        public ActionResult Details(int id)
        {
            var productDetails = _productService.GetProductDetails(id);
            var mapper = GetMapper<ProductBusinessModel, ProductViewModel>();
            var product = mapper.Map<ProductBusinessModel, ProductViewModel>(productDetails);
            return View(product);
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            //This action method is desinged to serve the purpose of creating/updating based on the productId.
            ProductViewModel productViewModel;
            if (id != 0)
            {
                var _productViewModel = _productService.GetProductDetails(id);
                var mapper = GetMapper<ProductBusinessModel, ProductViewModel>();
                productViewModel = mapper.Map<ProductBusinessModel, ProductViewModel>(_productViewModel);
            }
            else
            {
                productViewModel = new ProductViewModel();
            }
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            var mapper = GetMapper<ProductViewModel, ProductBusinessModel>();
            var product = mapper.Map<ProductViewModel, ProductBusinessModel>(productViewModel);
            if (productViewModel.Id != 0)
            {
                _productService.Update(product);
            }
            else
            {
                _productService.Add(product);
            }

            //returns to the listing View after the successful Operation.
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult Update(int productId)
        {
            var productDetails = _productService.GetProductDetails(productId);
            var mapper = GetMapper<ProductBusinessModel, ProductViewModel>();
            var product = mapper.Map<ProductBusinessModel, ProductViewModel>(productDetails);
            return View(product);
        }


        [HttpPost]
        public ActionResult Update(ProductViewModel productViewModel)
        {
            var mapper = GetMapper<ProductViewModel, ProductBusinessModel>();
            var product = mapper.Map<ProductViewModel, ProductBusinessModel>(productViewModel);
            _productService.Update(product);
            return View();
        }
        private IMapper GetMapper<TSource, TDest>()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            return config.CreateMapper();
        }
    }
}