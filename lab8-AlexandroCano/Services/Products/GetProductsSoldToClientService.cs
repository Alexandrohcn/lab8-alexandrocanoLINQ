using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using lab8_AlexandroCano.Services.Products.Interfaces;

namespace lab8_AlexandroCano.Services.Products;

public class GetProductsSoldToClientService(IGetProductsSoldToClientRepository repository) : IGetProductsSoldToClientService
{
    public Task<IEnumerable<ProductSoldToClientDto>> ExecuteAsync(int clientId)
    {
        if (clientId <= 0)
        {
            throw new ArgumentException("El clientId debe ser mayor que 0.", nameof(clientId));
        }

        return repository.ExecuteAsync(clientId);
    }
}
