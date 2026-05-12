using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using lab8_AlexandroCano.Services.Products.Interfaces;

namespace lab8_AlexandroCano.Services.Products.Implementacion;

public class GetProductsByPriceService(IGetProductsByPriceRepository repository) : IGetProductsByPriceService
{
    public Task<IEnumerable<ProductDto>> ExecuteAsync(decimal minPrice)
    {
        if (minPrice < 0)
        {
            throw new ArgumentException("El precio mínimo no puede ser negativo.", nameof(minPrice));
        }

        return repository.ExecuteAsync(minPrice);
    }
}
