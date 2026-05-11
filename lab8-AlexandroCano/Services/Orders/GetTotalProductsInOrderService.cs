using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using lab8_AlexandroCano.Services.Orders.Interfaces;

namespace lab8_AlexandroCano.Services.Orders;

public class GetTotalProductsInOrderService(IGetTotalProductsInOrderRepository repository) : IGetTotalProductsInOrderService
{
    public async Task<OrderTotalProductsDto> ExecuteAsync(int orderId)
    {
        if (orderId <= 0)
        {
            throw new ArgumentException("El orderId debe ser mayor que 0.", nameof(orderId));
        }

        var total = await repository.ExecuteAsync(orderId);
        return new OrderTotalProductsDto
        {
            OrderId = orderId,
            TotalProducts = total
        };
    }
}
