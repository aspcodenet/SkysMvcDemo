using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using SkysMvcDemo.Models;

namespace SkysMvcDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowOne(int bajskorv)
        {
            return View();
        }

    }
}