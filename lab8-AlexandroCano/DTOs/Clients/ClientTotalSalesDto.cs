namespace lab8_AlexandroCano.DTOs.Clients;

public class ClientTotalSalesDto
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public decimal TotalSales { get; set; }
}
