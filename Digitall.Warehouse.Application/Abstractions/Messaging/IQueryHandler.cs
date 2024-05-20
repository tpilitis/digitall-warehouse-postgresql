using Digitall.Warehouse.Domain.Shared;
using MediatR;

namespace Digitall.Warehouse.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
