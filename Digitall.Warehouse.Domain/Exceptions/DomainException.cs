using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Domain.Exceptions
{
    public abstract class DomainException(Error error) : Exception(error.Description)
    {
        public Error Error { get; init; } = error;
    }
}
