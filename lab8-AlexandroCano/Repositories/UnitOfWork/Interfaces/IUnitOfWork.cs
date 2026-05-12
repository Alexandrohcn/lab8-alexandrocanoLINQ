namespace lab8_AlexandroCano.Repositories.UnitOfWork.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    Task<int> SaveAsync();
}
