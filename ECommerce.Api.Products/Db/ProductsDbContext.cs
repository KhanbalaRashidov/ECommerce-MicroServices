using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Db
{
    public class ProductsDbContext:DbContext
    {
        public ProductsDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
