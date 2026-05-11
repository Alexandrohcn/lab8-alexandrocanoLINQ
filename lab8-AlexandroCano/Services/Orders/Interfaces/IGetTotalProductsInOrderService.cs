using lab8_AlexandroCano.DTOs.Orders;

namespace lab8_AlexandroCano.Services.Orders.Interfaces;

public interface IGetTotalProductsInOrderService
{
    Task<OrderTotalProductsDto> ExecuteAsync(int orderId);
}
