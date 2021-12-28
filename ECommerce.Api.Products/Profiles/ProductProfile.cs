using AutoMapper;

namespace ECommerce.Api.Products.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Db.Product, Models.Product>();    
        }
    }
}
