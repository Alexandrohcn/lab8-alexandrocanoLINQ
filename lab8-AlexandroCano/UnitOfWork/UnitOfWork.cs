using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.Repositories.Interfaces;

namespace lab8_AlexandroCano.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IClientRepository Clients { get; }
    public IProductRepository Products { get; }
    public IOrderRepository Orders { get; }

    public UnitOfWork(
        AppDbContext context,
        IClientRepository clients,
        IProductRepository products,
        IOrderRepository orders)
    {
        _context = context;
        Clients = clients;
        Products = products;
        Orders = orders;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}