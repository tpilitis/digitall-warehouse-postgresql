using System.Security.Authentication.ExtendedProtection;

namespace Digitall.Warehouse.Domain.Abstraction
{
    public abstract class Entity(Guid id) : IIdentifiable<Guid>
    {
        public Guid Id { get; set; } = id;

        protected Entity() : this(Guid.NewGuid())
        {
        }
    }
}
