using lab8_AlexandroCano.DTOs.Orders;

namespace lab8_AlexandroCano.Repositories.Orders.Interfaces;

public interface IGetOrdersAfterDateRepository
{
    Task<IEnumerable<OrderSummaryDto>> ExecuteAsync(DateTime date);
}
