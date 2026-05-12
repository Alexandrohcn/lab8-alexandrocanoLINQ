using lab8_AlexandroCano.Services.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Clients;

// LAB 9 - PASO 5: expone la agrupación GroupBy + Sum + OrderByDescending (total de ventas por cliente).
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
