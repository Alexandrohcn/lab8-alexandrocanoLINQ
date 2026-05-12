using lab8_AlexandroCano.Services.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Orders;

// LAB 9 - PASO 3: expone la consulta con Include() para traer Product asociado al detalle.
[ApiController]
[Route("api/Orders")]
public class GetOrderDetailsController(IGetOrderDetailsService getOrderDetailsService) : ControllerBase
{
    [HttpGet("{orderId:int}/details")]
    public async Task<IActionResult> GetOrderDetails(int orderId)
    {
        try
        {
            var details = await getOrderDetailsService.ExecuteAsync(orderId);
            return Ok(details);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}
