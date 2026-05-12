using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.Repositories.UnitOfWork.Interfaces;

namespace lab8_AlexandroCano.Repositories.UnitOfWork.Implementacion;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveAsync()
    {
        return context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}
