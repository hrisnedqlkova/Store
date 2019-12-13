using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.Models.OnlineStoreContext;
using OnlineStore.VModels;

namespace OnlineStore.WebApp.Controllers
{
    public class RegistrationController : Controller
    {
		Context _context = new Context();
		[HttpGet]
        public IActionResult Index()
        {
			RegistrationVmodel model = new RegistrationVmodel();
            return View(model);
        }
		[HttpPost]
		public async Task<IActionResult> Index(RegistrationVmodel model)
		{
			if (ModelState.IsValid)
			{
				if (model.Password == model.ConfirmPassword)
				{
					User entityUser = new User();
					entityUser.FName = model.FName;
					entityUser.SName = model.SName;

					
					LoginModel login = new LoginModel();
					login.Email = model.Email;
					login.Password = model.Password;
					
					_context.Add(entityUser);
					_context.Add(login);
					await _context.SaveChangesAsync();
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Passwords do not match");
					return View(model);
				}
			}
			return View("../Home/Index");
		}

	}
}