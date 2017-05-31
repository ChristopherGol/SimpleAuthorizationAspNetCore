using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthorizationAspNetCore.Data;
using SimpleAuthorizationAspNetCore.Model;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAuthorizationAspNetCore.Controllers
{
    public class Login : Controller
    {
        private readonly ForumContext context;

        public Login(ForumContext forumContext)
        {
            this.context = forumContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorize(User user, string returnUrl = null)
        {
            User authUser = context.Users.FirstOrDefault(x => x.Login == user.Login && x.Password == Secure.MD5Hash(user.Password));

            if (authUser != null)
            {
                authUser.LastLogin = DateTime.Now;
                context.Users.Update(authUser);
                context.SaveChanges();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, authUser.Login)
            };

                var identity = new ClaimsIdentity(claims, "Name");
                var userPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.Authentication.SignInAsync("SimpleCookieAuthorization", userPrincipal, new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                return RedirectToAction("Index", "Admin");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }
    }
}
