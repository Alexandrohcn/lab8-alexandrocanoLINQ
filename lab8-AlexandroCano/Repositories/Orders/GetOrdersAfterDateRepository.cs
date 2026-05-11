using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Orders;

public class GetOrdersAfterDateRepository(AppDbContext context) : IGetOrdersAfterDateRepository
{
    public async Task<IEnumerable<OrderSummaryDto>> ExecuteAsync(DateTime date)
    {
        return await context.Orders
            .AsNoTracking()
            .Where(o => o.OrderDate > date)
            .Select(o => new OrderSummaryDto
            {
                OrderId = o.OrderId,
                ClientId = o.ClientId,
                OrderDate = o.OrderDate
            })
            .ToListAsync();
    }
}
