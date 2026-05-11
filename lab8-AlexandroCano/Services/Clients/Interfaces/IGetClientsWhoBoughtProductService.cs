using lab8_AlexandroCano.DTOs.Clients;

namespace lab8_AlexandroCano.Services.Clients.Interfaces;

public interface IGetClientsWhoBoughtProductService
{
    Task<IEnumerable<ClientWhoBoughtProductDto>> ExecuteAsync(int productId);
}
