using Digitall.Warehouse.Domain.Shared;
using FluentValidation.Results;

namespace Digitall.Warehouse.Api.Infrastructure.ExceptionHandling.Models;

public class ValidationErrorResponse
{
    public ValidationErrorResponse(IEnumerable<ValidationFailure> failures) => Errors = failures.Select(f => new ErrorResponse(f.ErrorCode, f.ErrorMessage));
    public ValidationErrorResponse(IEnumerable<ErrorResponse> errors) => Errors = errors;
    public ValidationErrorResponse(Error error) => Errors = [new ErrorResponse(error.Code, error.Description)];

    public IEnumerable<ErrorResponse> Errors { get; set; } = [];
}
