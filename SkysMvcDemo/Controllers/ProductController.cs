using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using SkysMvcDemo.Models;
using SkysMvcDemo.ViewModels;

namespace SkysMvcDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var viewModel = new ProductListViewModel();
            viewModel.Items = _dbContext.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            var viewModel = new ProductNewViewModel();
            //Filldropdown()
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(ProductNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.Color = viewModel.Color;
                product.Ean13 = viewModel.Ean13;
                product.PopularityPercent = viewModel.PopularityPercent;

                _dbContext.Products.Add(product);
                //mappa till objekt från viewmodel
                _dbContext.SaveChanges();
                //Save to db

                //Redirect
                return RedirectToAction("Index", "Product");
            }

            //Filldropdown()
            return View(viewModel);
        }




        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var viewModel = new ProductEditViewModel();
            var product = _dbContext.Products.First(p => p.Id == productId);
            viewModel.Name = product.Name;
            viewModel.Price = Convert.ToInt32(product.Price);
            viewModel.Color = product.Color;
            viewModel.Ean13 = product.Ean13;
            viewModel.PopularityPercent = product.PopularityPercent;

            // fylla viewmodel från databas
            //anropa View och skicka in viewModel
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int productId, ProductEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //Hämta objjekt från db
                var product = _dbContext.Products.First(p => p.Id == productId);
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.Color = viewModel.Color;
                product.Ean13 = viewModel.Ean13;
                product.PopularityPercent = viewModel.PopularityPercent;
                //mappa till objekt från viewmodel
                _dbContext.SaveChanges();
                //Save to db

                //Redirect
                return RedirectToAction("Index", "Product");
            }

            return View(viewModel);
        }

        public IActionResult ShowOne(int bajskorv)
        {
            var product = _dbContext.Products.First(e => e.Id == bajskorv);
            var viewModel = new ProductViewModel();
            viewModel.Name = product.Name;
            viewModel.Price = product.Price;
            viewModel.Id = product.Id;
            return View(viewModel);
        }

    }
}