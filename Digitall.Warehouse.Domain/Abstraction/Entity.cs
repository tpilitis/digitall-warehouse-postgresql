namespace Digitall.Warehouse.Domain.Abstraction
{
    public abstract class Entity<TId> : IIdentifiable<TId>
    {
        public TId Id { get; set; } = default!;
    }
}
