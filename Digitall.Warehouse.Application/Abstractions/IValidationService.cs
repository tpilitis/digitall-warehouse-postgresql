using FluentValidation.Results;
using MediatR;

namespace Digitall.Warehouse.Application.Abstractions;

public interface IValidationService
{
    Task<IEnumerable<ValidationFailure>> ValidateRequestAsync<TRequest>(
        TRequest request,
        IEnumerable<FluentValidation.IValidator<TRequest>> validators,
        CancellationToken cancellationToken)
        where TRequest : IBaseRequest;
}
