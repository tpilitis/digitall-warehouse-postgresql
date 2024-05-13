namespace Digitall.Warehouse.Domain.Entities.Products;

/// <summary>
/// Price complext type.
/// </summary>
/// <param name="Value">Price Value</param>
/// <param name="CurrencyCode">ISO Currency code</param>
public record Price(decimal Value, string CurrencyCode);
