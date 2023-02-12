using Microsoft.EntityFrameworkCore;
using Product.Domain.Configurations;
using Product.Domain.Models;

namespace Product.Domain
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductItem> ProductItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=../../Product.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfiguration(new ProductItemConfiguration());
    }

}