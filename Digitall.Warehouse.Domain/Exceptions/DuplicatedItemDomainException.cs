using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Domain.Exceptions;

public class DuplicatedItemDomainException(Error error) : DomainException(error)
{
}
