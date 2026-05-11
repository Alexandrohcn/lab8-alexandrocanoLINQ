using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using lab8_AlexandroCano.Services.Orders.Interfaces;

namespace lab8_AlexandroCano.Services.Orders;

public class GetOrdersAfterDateService(IGetOrdersAfterDateRepository repository) : IGetOrdersAfterDateService
{
    public Task<IEnumerable<OrderSummaryDto>> ExecuteAsync(DateTime date)
    {
        return repository.ExecuteAsync(date);
    }
}
