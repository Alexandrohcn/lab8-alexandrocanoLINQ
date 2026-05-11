namespace lab8_AlexandroCano.Repositories.Products.Interfaces;

public interface IGetAveragePriceRepository
{
    Task<decimal> ExecuteAsync();
}
