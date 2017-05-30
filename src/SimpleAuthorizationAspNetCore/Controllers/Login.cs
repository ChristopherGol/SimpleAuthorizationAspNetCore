using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthorizationAspNetCore.Data;
using SimpleAuthorizationAspNetCore.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAuthorizationAspNetCore.Controllers
{
    public class Login : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Authorize(User user)
        {
            return RedirectToAction("Index", "Admin");
        }
    }
}
