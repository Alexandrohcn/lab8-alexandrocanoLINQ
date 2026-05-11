using lab8_AlexandroCano.Services.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Orders;

[ApiController]
[Route("api/Orders")]
public class GetTotalProductsInOrderController(IGetTotalProductsInOrderService getTotalProductsInOrderService) : ControllerBase
{
    [HttpGet("{orderId:int}/total-products")]
    public async Task<IActionResult> GetTotalProductsInOrder(int orderId)
    {
        try
        {
            var total = await getTotalProductsInOrderService.ExecuteAsync(orderId);
            return Ok(total);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}
