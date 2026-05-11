using lab8_AlexandroCano.Services.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Clients;

[ApiController]
[Route("api/Clients")]
public class GetClientsWithTotalProductsController(IGetClientsWithTotalProductsService getClientsWithTotalProductsService) : ControllerBase
{
    [HttpGet("total-products")]
    public async Task<IActionResult> GetClientsWithTotalProducts()
    {
        var clients = await getClientsWithTotalProductsService.ExecuteAsync();
        return Ok(clients);
    }
}
