using lab8_AlexandroCano.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet("price")]
    public async Task<IActionResult> GetProductsByPrice([FromQuery] decimal minPrice)
    {
        var products = await _unitOfWork.Products.GetProductsByPriceAsync(minPrice);
        return Ok(products);
    }


    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var product = await _unitOfWork.Products.GetMostExpensiveProductAsync();

        if (product == null)
        {
            return NotFound(new { Message = "No se encontraron productos." });
        }

        return Ok(product);
    }


    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var average = await _unitOfWork.Products.GetAveragePriceAsync();

        return Ok(new
        {
            AveragePrice = average
        });
    }


    [HttpGet("without-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var products = await _unitOfWork.Products.GetProductsWithoutDescriptionAsync();
        return Ok(products);
    }


    [HttpGet("client/{clientId:int}")]
    public async Task<IActionResult> GetProductsSoldToClient(int clientId)
    {
        var products = await _unitOfWork.Products.GetProductsSoldToClientAsync(clientId);
        return Ok(products);
    }
}