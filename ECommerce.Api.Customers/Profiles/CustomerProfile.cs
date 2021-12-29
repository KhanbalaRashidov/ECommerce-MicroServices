using AutoMapper;

namespace ECommerce.Api.Customers.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Db.Customer, Models.Customer>();
        }
    }
}
