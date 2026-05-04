using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetOrderDetailsAsync(int orderId)
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .Include(od => od.Product)
            .Select(od => new
            {
                od.OrderId,
                ProductName = od.Product.Name,
                od.Quantity
            })
            .ToListAsync();
    }

    public async Task<int> GetTotalProductsInOrderAsync(int orderId)
    {
        return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => od.Quantity);
    }

    public async Task<IEnumerable<object>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.OrderDate > date)
            .Select(o => new
            {
                o.OrderId,
                o.ClientId,
                o.OrderDate
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetAllOrdersDetailsAsync()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .Select(o => new
            {
                o.OrderId,
                ClientName = o.Client.Name,
                o.OrderDate,
                Details = o.OrderDetails.Select(od => new
                {
                    ProductName = od.Product.Name,
                    od.Quantity
                })
            })
            .ToListAsync();
    }
}