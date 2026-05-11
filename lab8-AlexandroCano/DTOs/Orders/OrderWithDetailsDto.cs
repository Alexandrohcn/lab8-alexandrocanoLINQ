namespace lab8_AlexandroCano.DTOs.Orders;

public class OrderWithDetailsDto
{
    public int OrderId { get; set; }
    public string ClientName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public IEnumerable<OrderProductLineDto> Details { get; set; } = new List<OrderProductLineDto>();
}
