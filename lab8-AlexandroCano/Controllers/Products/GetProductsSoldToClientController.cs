using lab8_AlexandroCano.Services.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Products;

[ApiController]
[Route("api/Products")]
public class GetProductsSoldToClientController(IGetProductsSoldToClientService getProductsSoldToClientService) : ControllerBase
{
    [HttpGet("client/{clientId:int}")]
    public async Task<IActionResult> GetProductsSoldToClient(int clientId)
    {
        try
        {
            var products = await getProductsSoldToClientService.ExecuteAsync(clientId);
            return Ok(products);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}
