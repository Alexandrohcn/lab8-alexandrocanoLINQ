namespace lab8_AlexandroCano.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<object>> GetOrderDetailsAsync(int orderId);
    Task<int> GetTotalProductsInOrderAsync(int orderId);
    Task<IEnumerable<object>> GetOrdersAfterDateAsync(DateTime date);
    Task<IEnumerable<object>> GetAllOrdersDetailsAsync();
}