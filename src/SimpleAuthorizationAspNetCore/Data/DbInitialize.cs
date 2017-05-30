using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAuthorizationAspNetCore.Model;

namespace SimpleAuthorizationAspNetCore.Data
{
    public static class DbInitialize
    {
        public static void Initialize(ForumContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new List<User>();
            users.Add(new User { Login = "admin", Password = Secure.MD5Hash("admin"), LastLogin=DateTime.MinValue });
            users.Add(new User { Login = "root", Password = Secure.MD5Hash("root"), LastLogin = DateTime.MinValue });

            foreach(User user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

        }
    }
}
