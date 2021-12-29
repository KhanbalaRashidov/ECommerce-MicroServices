using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Customers.Providers
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly CustomersDbContext _dbContext;
        private readonly ILogger<CustomersProvider> _logger;
        private readonly IMapper _mapper;

        public CustomersProvider(CustomersDbContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!_dbContext.Customers.Any())
            {
                _dbContext.Customers.AddAsync(new Db.Customer { Id = 1, Name = "Customer1", Address = "Address1" });
                _dbContext.Customers.AddAsync(new Db.Customer { Id = 2, Name = "Customer2", Address = "Address2" });
                _dbContext.Customers.AddAsync(new Db.Customer { Id = 3, Name = "Customer3", Address = "Address3" });
                _dbContext.Customers.AddAsync(new Db.Customer { Id = 4, Name = "Customer4", Address = "Address4" });
                _dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync()
        {
            try
            {
                _logger?.LogInformation("Querying customers");
                var customers = await _dbContext.Customers.ToListAsync();

                if (customers !=null && customers.Any())
                {
                    _logger?.LogInformation($"{customers.Count} customer(s) found");
                    var result = _mapper.Map<IEnumerable<Db.Customer>,IEnumerable<Models.Customer>>(customers);
                    return (true, result, null);
                }
                return (false, null, "Not found");

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
               
            }
        }

        public async Task<(bool IsSuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id)
        {
            try
            {
                _logger?.LogInformation("Querying customers");
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(c=>c.Id==id);

                if (customer != null)
                {
                    _logger?.LogInformation("Customer found");
                    var result = _mapper.Map<Db.Customer, Models.Customer>(customer);
                    return (true, result, null);
                }
                return (false, null, "Not found");

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);

            }
        }
    }
}
