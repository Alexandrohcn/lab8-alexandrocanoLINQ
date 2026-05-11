namespace lab8_AlexandroCano.Repositories.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    Task<int> SaveAsync();
}
