using lab8_AlexandroCano.DTOs.Orders;

namespace lab8_AlexandroCano.Services.Orders.Interfaces;

public interface IGetOrderDetailsService
{
    Task<IEnumerable<OrderDetailItemDto>> ExecuteAsync(int orderId);
}
