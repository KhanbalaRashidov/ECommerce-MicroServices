using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Db
{
    public class OrdersDbContext:DbContext
    {
        public OrdersDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
   
}
