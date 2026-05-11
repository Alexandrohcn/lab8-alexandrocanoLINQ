using lab8_AlexandroCano.DTOs.Products;

namespace lab8_AlexandroCano.Services.Products.Interfaces;

public interface IGetProductsByPriceService
{
    Task<IEnumerable<ProductDto>> ExecuteAsync(decimal minPrice);
}
