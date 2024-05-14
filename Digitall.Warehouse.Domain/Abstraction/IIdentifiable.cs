namespace Digitall.Warehouse.Domain.Abstraction;

public interface IIdentifiable<TId>
{
    TId Id { get; set; }
}
