namespace Digitall.Warehouse.Api.Contracts.Requests.Products;

public class Money
{
    public decimal Price { get; set; }

    public string CurrencyCode { get; set; } = default!;
}
