using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Orders.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider _ordersProvider;
        public OrdersController(IOrdersProvider ordersProvider)
        {
            _ordersProvider = ordersProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int cutomerId)
        {
            var result = await _ordersProvider.GetOdersAsync(cutomerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}
