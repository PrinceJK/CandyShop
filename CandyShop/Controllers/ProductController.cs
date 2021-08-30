using CandyShop.Core.Interface;
using CandyShop.Models;
using CandyShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CandyShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Product> products;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.GetAllProducts.OrderBy(c => c.Id);
                currentCategory = "All Products";
            }
            else
            {
                products = _productRepository.GetAllProducts.Where(c => c.Category.Name == category);

                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.Name == category)?.Name;
            }

            return View(new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(string id)
        {
            var candy = _productRepository.GetProductById(id);
            if (candy == null)
            {
                return NotFound();
            }
            else
            {
                return View(candy);
            }
        }
    }
}