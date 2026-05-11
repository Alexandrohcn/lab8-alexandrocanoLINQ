using lab8_AlexandroCano.Services.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Clients;

[ApiController]
[Route("api/Clients")]
public class GetClientsTotalSalesController(IGetClientsTotalSalesService getClientsTotalSalesService) : ControllerBase
{
    [HttpGet("total-sales")]
    public async Task<IActionResult> GetClientsTotalSales()
    {
        var clients = await getClientsTotalSalesService.ExecuteAsync();
        return Ok(clients);
    }
}
