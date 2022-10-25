using Microsoft.EntityFrameworkCore;
using ProductEntity.Models;
using System;

namespace ProductData.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext()
        {

        }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Colour> colours { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<SizeScale> sizescales { get; set; }
        public DbSet<Create> creates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2106; Initial Catalog=Prd67; Integrated Security=true;");
        }
    }
}
