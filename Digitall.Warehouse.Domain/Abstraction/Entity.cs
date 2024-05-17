namespace Digitall.Warehouse.Domain.Abstraction
{
    public abstract class Entity(Guid id) : IIdentifiable<Guid>, IAuditable
    {
        public Guid Id { get; set; } = id;

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        protected Entity() : this(Guid.NewGuid())
        {
        }
    }
}
