using lab8_AlexandroCano.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet("search")]
    public async Task<IActionResult> GetClientsByName([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new { Message = "El parámetro name es obligatorio." });
        }

        var clients = await _unitOfWork.Clients.GetClientsByNameAsync(name);
        return Ok(clients);
    }


    [HttpGet("most-orders")]
    public async Task<IActionResult> GetClientWithMostOrders()
    {
        var client = await _unitOfWork.Clients.GetClientWithMostOrdersAsync();

        if (client == null)
        {
            return NotFound(new { Message = "No se encontraron pedidos registrados." });
        }

        return Ok(client);
    }


    [HttpGet("product/{productId:int}")]
    public async Task<IActionResult> GetClientsWhoBoughtProduct(int productId)
    {
        var clients = await _unitOfWork.Clients.GetClientsWhoBoughtProductAsync(productId);
        return Ok(clients);
    }
}