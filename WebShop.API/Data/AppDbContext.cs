using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.API.Models.Entities;

namespace WebShop.API.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ColorEntity> Colors { get; set; }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<SizeEntity> Sizes { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<TagEntity> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductTag>().HasKey(t => new { t.Tag, t.ProductId });
            base.OnModelCreating(builder);
        }
    }
}
