using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using lab8_AlexandroCano.Services.Orders.Interfaces;

namespace lab8_AlexandroCano.Services.Orders;

public class GetOrderDetailsService(IGetOrderDetailsRepository repository) : IGetOrderDetailsService
{
    public Task<IEnumerable<OrderDetailItemDto>> ExecuteAsync(int orderId)
    {
        if (orderId <= 0)
        {
            throw new ArgumentException("El orderId debe ser mayor que 0.", nameof(orderId));
        }

        return repository.ExecuteAsync(orderId);
    }
}
