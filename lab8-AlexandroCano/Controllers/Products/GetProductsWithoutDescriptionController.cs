using lab8_AlexandroCano.Services.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Products;

[ApiController]
[Route("api/Products")]
public class GetProductsWithoutDescriptionController(IGetProductsWithoutDescriptionService getProductsWithoutDescriptionService) : ControllerBase
{
    [HttpGet("without-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var products = await getProductsWithoutDescriptionService.ExecuteAsync();
        return Ok(products);
    }
}
