using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using lab8_AlexandroCano.Services.Products.Interfaces;

namespace lab8_AlexandroCano.Services.Products.Implementacion;

public class GetProductsWithoutDescriptionService(IGetProductsWithoutDescriptionRepository repository) : IGetProductsWithoutDescriptionService
{
    public Task<IEnumerable<ProductDto>> ExecuteAsync()
    {
        return repository.ExecuteAsync();
    }
}
