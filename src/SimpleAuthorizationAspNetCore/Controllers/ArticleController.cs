using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthorizationAspNetCore.Data;
using SimpleAuthorizationAspNetCore.Model;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAuthorizationAspNetCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly ForumContext context;

        public ArticleController(ForumContext forumContext)
        {
            this.context = forumContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return context.Articles.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Article Get(int id)
        {
            return context.Articles.FirstOrDefault(x => x.ID == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Article article)
        {
            context.Articles.Add(article);
            context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Article article = context.Articles.FirstOrDefault(x => x.ID == id);

            context.Articles.Remove(article);
            context.SaveChanges();
        }
    }
}
