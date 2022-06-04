using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStoreTask.Data
{
    public class BKContext:IdentityDbContext<ApplicationUser>

    {
        IConfiguration config;
        public BKContext(IConfiguration _config)
        {
            config = _config;
        }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Nationality> nationalities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("BookCS"));
            //optionsBuilder.UseSqlServer("data source=localhost;integrated security=true;initial catalog=DBBookSystem");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
