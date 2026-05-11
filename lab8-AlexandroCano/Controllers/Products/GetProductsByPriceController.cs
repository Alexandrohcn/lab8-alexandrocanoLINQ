using lab8_AlexandroCano.Services.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Products;

[ApiController]
[Route("api/Products")]
public class GetProductsByPriceController(IGetProductsByPriceService getProductsByPriceService) : ControllerBase
{
    [HttpGet("price")]
    public async Task<IActionResult> GetProductsByPrice([FromQuery] decimal minPrice)
    {
        try
        {
            var products = await getProductsByPriceService.ExecuteAsync(minPrice);
            return Ok(products);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}
