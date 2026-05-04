using lab8_AlexandroCano.Models;

namespace lab8_AlexandroCano.Repositories.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
    Task<object?> GetClientWithMostOrdersAsync();
    Task<IEnumerable<object>> GetClientsWhoBoughtProductAsync(int productId);
}