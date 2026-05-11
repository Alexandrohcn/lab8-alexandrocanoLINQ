using lab8_AlexandroCano.Services.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Clients;

[ApiController]
[Route("api/Clients")]
public class GetClientWithMostOrdersController(IGetClientWithMostOrdersService getClientWithMostOrdersService) : ControllerBase
{
    [HttpGet("most-orders")]
    public async Task<IActionResult> GetClientWithMostOrders()
    {
        var client = await getClientWithMostOrdersService.ExecuteAsync();
        if (client == null)
        {
            return NotFound(new { Message = "No se encontraron pedidos registrados." });
        }
        return Ok(client);
    }
}
