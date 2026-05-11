using lab8_AlexandroCano.Services.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Clients;

[ApiController]
[Route("api/Clients")]
public class GetClientsWhoBoughtProductController(IGetClientsWhoBoughtProductService getClientsWhoBoughtProductService) : ControllerBase
{
    [HttpGet("product/{productId:int}")]
    public async Task<IActionResult> GetClientsWhoBoughtProduct(int productId)
    {
        try
        {
            var clients = await getClientsWhoBoughtProductService.ExecuteAsync(productId);
            return Ok(clients);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}
