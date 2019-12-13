using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.Models.OnlineStoreContext;
using OnlineStore.VModels;

namespace OnlineStore.WebApp.Controllers
{
    public class LoginController : Controller
    {
		Context _context = new Context();
		[HttpGet]
        public IActionResult Index()
        {
			LoginVModel model = new LoginVModel();
            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Index(LoginVModel model)
		{
			if (ModelState.IsValid)
			{
				var isUserExist = await _context.LoginModels.Where(x => x.Email == model.Email).ToListAsync();
				if (isUserExist.Count == 0)
				{
					ModelState.AddModelError(string.Empty, "This user doesn't exist");
					return View();
				}
				else
				{
					LoginModel login = isUserExist.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

					HttpContext.Session.SetString("User", login.Id.ToString());
					
					
					return Redirect("../Home/Index");
				}
			}
			return View("../Home/Index");
        }
    }
}