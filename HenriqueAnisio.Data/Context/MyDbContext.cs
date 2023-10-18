using HenriqueAnisio.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HenriqueAnisio.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
