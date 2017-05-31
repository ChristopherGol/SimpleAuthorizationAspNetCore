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
            users.Add(new User { Login = "admin", Password = Secure.MD5Hash("admin"), LastLogin = DateTime.MinValue });
            users.Add(new User { Login = "root", Password = Secure.MD5Hash("root"), LastLogin = DateTime.MinValue });

            foreach (User user in users)
            {
                context.Users.Add(user);
            }

            //context.SaveChanges();

            var articles = new List<Article>();
            articles.Add(new Article { AuthorID = users.FirstOrDefault(x => x.Login == "admin").ID, Title = "Example title", Text = "Example text", PublishTime = DateTime.Now });
            articles.Add(new Article { AuthorID = users.FirstOrDefault(x => x.Login == "root").ID, Title = "Example title", Text = "Example text", PublishTime = DateTime.Now });
            articles.Add(new Article { AuthorID = users.FirstOrDefault(x => x.Login == "admin").ID, Title = "Example title", Text = "Example text", PublishTime = DateTime.Now });

            foreach (Article article in articles)
            {
                context.Articles.Add(article);
            }

            context.SaveChanges();

        }
    }
}
