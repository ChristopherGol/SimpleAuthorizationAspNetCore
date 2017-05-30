using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAuthorizationAspNetCore.Model;

namespace SimpleAuthorizationAspNetCore.Data
{
    public class ForumContext: DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
