namespace Digitall.Warehouse.Domain.Abstraction;

public interface IIdentifiable<out TId>
{
    TId Id { get; }
}
