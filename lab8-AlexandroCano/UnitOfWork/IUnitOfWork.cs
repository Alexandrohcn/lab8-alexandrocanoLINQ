using lab8_AlexandroCano.Repositories.Interfaces;

namespace lab8_AlexandroCano.UnitOfWork;

public interface IUnitOfWork
{
    IClientRepository Clients { get; }
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }

    Task<int> SaveAsync();
}