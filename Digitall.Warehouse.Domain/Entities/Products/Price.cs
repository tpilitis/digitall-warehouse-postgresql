using System.ComponentModel.DataAnnotations.Schema;

namespace Digitall.Warehouse.Domain.Entities.Products
{
    /// <summary>
    /// TODO: This shall be a value type when we create EF initial db - part of the same table.
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="CurrencyCode"></param>
    [ComplexType]
    public record Price (decimal Value, string CurrencyCode);
}
