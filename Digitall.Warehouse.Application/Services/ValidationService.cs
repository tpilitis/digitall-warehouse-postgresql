using Digitall.Warehouse.Application.Abstractions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Digitall.Warehouse.Application.Services
{
    public class ValidationService : IValidationService
    {
        public async Task<IEnumerable<ValidationFailure>> ValidateRequestAsync<TRequest>(
            TRequest request,
            IEnumerable<IValidator<TRequest>> validators,
            CancellationToken cancellationToken)
            where TRequest : IBaseRequest
        {
            if (!validators.Any())
            {
                return [];
            }

            var context = new ValidationContext<TRequest>(request);
            var validationFailures = await Task
            .WhenAll(validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));

            var errors = validationFailures
                .SelectMany(validator => validator.Errors)
                .Where(error => error is not null);

            return errors;
        }
    }
}
