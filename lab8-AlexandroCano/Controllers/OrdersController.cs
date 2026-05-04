using lab8_AlexandroCano.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace lab8_AlexandroCano.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet("{orderId:int}/details")]
    public async Task<IActionResult> GetOrderDetails(int orderId)
    {
        var details = await _unitOfWork.Orders.GetOrderDetailsAsync(orderId);
        return Ok(details);
    }


    [HttpGet("{orderId:int}/total-products")]
    public async Task<IActionResult> GetTotalProductsInOrder(int orderId)
    {
        var total = await _unitOfWork.Orders.GetTotalProductsInOrderAsync(orderId);

        return Ok(new
        {
            OrderId = orderId,
            TotalProducts = total
        });
    }


    [HttpGet("after-date")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = await _unitOfWork.Orders.GetOrdersAfterDateAsync(date);
        return Ok(orders);
    }


    [HttpGet("details")]
    public async Task<IActionResult> GetAllOrdersDetails()
    {
        var orders = await _unitOfWork.Orders.GetAllOrdersDetailsAsync();
        return Ok(orders);
    }
}