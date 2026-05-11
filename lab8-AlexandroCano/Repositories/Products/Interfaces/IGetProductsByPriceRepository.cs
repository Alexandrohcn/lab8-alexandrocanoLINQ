using lab8_AlexandroCano.DTOs.Products;

namespace lab8_AlexandroCano.Repositories.Products.Interfaces;

public interface IGetProductsByPriceRepository
{
    Task<IEnumerable<ProductDto>> ExecuteAsync(decimal minPrice);
}
