using lab8_AlexandroCano.DTOs.Orders;

namespace lab8_AlexandroCano.Repositories.Orders.Interfaces;

public interface IGetOrderDetailsRepository
{
    Task<IEnumerable<OrderDetailItemDto>> ExecuteAsync(int orderId);
}
