using lab8_AlexandroCano.DTOs.Products;

namespace lab8_AlexandroCano.Repositories.Products.Interfaces;

public interface IGetProductsSoldToClientRepository
{
    Task<IEnumerable<ProductSoldToClientDto>> ExecuteAsync(int clientId);
}
