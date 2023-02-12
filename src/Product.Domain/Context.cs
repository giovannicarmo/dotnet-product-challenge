using Microsoft.EntityFrameworkCore;
using Product.Domain.Configurations;
using Product.Domain.Models;

namespace Product.Domain
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<ProductItem> ProductItems {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"C:\Temp\Product.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfiguration(new ProductItemConfiguration());
    }
}