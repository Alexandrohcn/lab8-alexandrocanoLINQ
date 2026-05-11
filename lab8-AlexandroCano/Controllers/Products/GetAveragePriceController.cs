using lab8_AlexandroCano.Services.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Products;

[ApiController]
[Route("api/Products")]
public class GetAveragePriceController(IGetAveragePriceService getAveragePriceService) : ControllerBase
{
    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var average = await getAveragePriceService.ExecuteAsync();
        return Ok(average);
    }
}
