using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OnlineStore.Models.OnlineStoreContext;
using OnlineStore.VModels;

namespace OnlineStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
		Context _context = new Context();
		[HttpGet]
        public IActionResult Index()
        {
			Product list = new Product();
			list.Products = _context.Products.ToList();
			return View(list);
		}
		[HttpGet]
		public IActionResult AddProduct()
		{
			AddProductVModel model = new AddProductVModel();
			return View(model);
		}
		[HttpPost]
		public IActionResult AddProduct(AddProductVModel model)
		{
			Product product = new Product();

			product.Name = model.Name;
			product.Price = model.Price;
			product.Description = model.Description;

			_context.Products.Add(product);

			_context.SaveChanges();

			return View(model);
		}

		[HttpGet]
		public IActionResult Edit()
		{
			
				Product entity = _context.Products.FirstOrDefault();
				AddProductVModel model = new AddProductVModel();
				model.Name = entity.Name;
			    model.Price = entity.Price;
			    model.Description = entity.Description;
			return View(model);
			
		}

		[HttpPost]
		public IActionResult Edit(AddProductVModel model)
		{
			
				Product entity = _context.Products.FirstOrDefault();
				entity.Name = model.Name;
			    entity.Price = model.Price;
			    entity.Description = model.Description;
			_context.Update(entity);
				_context.SaveChanges();
				return RedirectToAction("Index");
			
		}
	}
}