namespace Digitall.Warehouse.Domain.Abstraction
{
    public abstract class Entity(Guid identifier) : IIdentifiable<Guid>, IAuditable
    {
        public Guid Id { get; init; } = identifier;

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        protected Entity() : this(Guid.NewGuid())
        {
        }
    }
}
