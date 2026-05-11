using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Orders;

public class GetTotalProductsInOrderRepository(AppDbContext context) : IGetTotalProductsInOrderRepository
{
    public async Task<int> ExecuteAsync(int orderId)
    {
        return await context.OrderDetails
            .AsNoTracking()
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => od.Quantity);
    }
}
