using lab8_AlexandroCano.Services.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers.Products;

// LAB 9 - MEJORA PROPIA: expone la consulta OrderByDescending + FirstOrDefault (producto más caro).
[ApiController]
[Route("api/Products")]
public class GetMostExpensiveProductController(IGetMostExpensiveProductService getMostExpensiveProductService) : ControllerBase
{
    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var product = await getMostExpensiveProductService.ExecuteAsync();
        if (product == null)
        {
            return NotFound(new { Message = "No se encontraron productos." });
        }
        return Ok(product);
    }
}
