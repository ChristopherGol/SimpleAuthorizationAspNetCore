using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAuthorizationAspNetCore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult UnsecureAdminPage()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            // Sign out and destroy cookie authentication. 
            await HttpContext.Authentication.SignOutAsync("SimpleCookieAuthorization");

            // Redirect to login page. 
            return RedirectToAction("Index", "Login");
        }
    }
}
