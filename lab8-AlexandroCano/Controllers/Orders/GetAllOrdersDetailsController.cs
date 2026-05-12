using lab8_AlexandroCano.Services.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Orders;

// LAB 9 - PASO 3: expone la consulta con Include() + ThenInclude() (Order → Client / OrderDetails → Product).
[ApiController]
[Route("api/Orders")]
public class GetAllOrdersDetailsController(IGetAllOrdersDetailsService getAllOrdersDetailsService) : ControllerBase
{
    [HttpGet("details")]
    public async Task<IActionResult> GetAllOrdersDetails()
    {
        var orders = await getAllOrdersDetailsService.ExecuteAsync();
        return Ok(orders);
    }
}
