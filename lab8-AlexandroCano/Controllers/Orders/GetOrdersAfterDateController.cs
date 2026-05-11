using lab8_AlexandroCano.Services.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Orders;

[ApiController]
[Route("api/Orders")]
public class GetOrdersAfterDateController(IGetOrdersAfterDateService getOrdersAfterDateService) : ControllerBase
{
    [HttpGet("after-date")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = await getOrdersAfterDateService.ExecuteAsync(date);
        return Ok(orders);
    }
}
