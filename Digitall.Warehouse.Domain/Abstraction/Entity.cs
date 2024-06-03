namespace Digitall.Warehouse.Domain.Abstraction
{
    public abstract class Entity: IIdentifiable<Guid>, IAuditable
    {
        public Guid Id { get; init; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
