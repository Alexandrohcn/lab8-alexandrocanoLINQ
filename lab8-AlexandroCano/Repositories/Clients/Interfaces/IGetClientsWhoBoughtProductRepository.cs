using lab8_AlexandroCano.DTOs.Clients;

namespace lab8_AlexandroCano.Repositories.Clients.Interfaces;

public interface IGetClientsWhoBoughtProductRepository
{
    Task<IEnumerable<ClientWhoBoughtProductDto>> ExecuteAsync(int productId);
}
