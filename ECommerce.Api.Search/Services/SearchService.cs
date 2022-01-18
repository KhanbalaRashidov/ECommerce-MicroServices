using ECommerce.Api.Search.Interfaces;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersService _ordersService;
        public SearchService(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        public async Task<(bool IsSucccess, dynamic SearchResult)> SearchAsync(int customerId)
        {
            var ordersResult = await _ordersService.GetOrdersAsync(customerId);
            if (ordersResult.IsSuccess)
            {
                var result = new
                {
                    Orders = ordersResult.Orders,
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
