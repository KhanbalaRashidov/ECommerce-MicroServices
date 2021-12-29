using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Customers.Db
{
    public class CustomersDbContext:DbContext
    {
        public CustomersDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
