using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeroesAndDragons.Models
{
    public class DataContext : IdentityDbContext<User> /*DbContext*/
    {
        public DbSet<User> UsersBase { get; set; }
        public DbSet<Hit> Hits { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
    }
}
