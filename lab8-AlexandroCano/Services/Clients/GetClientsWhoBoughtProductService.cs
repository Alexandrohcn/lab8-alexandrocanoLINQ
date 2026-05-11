using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using lab8_AlexandroCano.Services.Clients.Interfaces;

namespace lab8_AlexandroCano.Services.Clients;

public class GetClientsWhoBoughtProductService(IGetClientsWhoBoughtProductRepository repository) : IGetClientsWhoBoughtProductService
{
    public Task<IEnumerable<ClientWhoBoughtProductDto>> ExecuteAsync(int productId)
    {
        if (productId <= 0)
        {
            throw new ArgumentException("El productId debe ser mayor que 0.", nameof(productId));
        }

        return repository.ExecuteAsync(productId);
    }
}
