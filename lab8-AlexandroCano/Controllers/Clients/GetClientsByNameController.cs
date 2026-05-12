using lab8_AlexandroCano.Services.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Clients;

// LAB 9 - PASO 2: expone la consulta AsNoTracking() + DTO (búsqueda de clientes por nombre).
[ApiController]
[Route("api/Clients")]
public class GetClientsByNameController(IGetClientsByNameService getClientsByNameService) : ControllerBase
{
    [HttpGet("search")]
    public async Task<IActionResult> GetClientsByName([FromQuery] string name)
    {
        try
        {
            var clients = await getClientsByNameService.ExecuteAsync(name);
            return Ok(clients);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}
