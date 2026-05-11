using lab8_AlexandroCano.DTOs.Products;

namespace lab8_AlexandroCano.Services.Products.Interfaces;

public interface IGetProductsSoldToClientService
{
    Task<IEnumerable<ProductSoldToClientDto>> ExecuteAsync(int clientId);
}
