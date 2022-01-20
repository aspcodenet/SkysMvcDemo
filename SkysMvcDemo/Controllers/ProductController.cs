using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using SkysMvcDemo.Models;
using SkysMvcDemo.ViewModels;

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
            List<ProductViewModel> viewModel = _productRepository.GetAll()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();
            return View(viewModel);
        }

        public IActionResult ShowOne(int bajskorv)
        {
            var product = _productRepository.GetAll().First(e => e.Id == bajskorv);
            var viewModel = new ProductViewModel();
            viewModel.Name = product.Name;
            viewModel.Price = product.Price;
            viewModel.Id = product.Id;
            return View(viewModel);
        }

    }
}