using Digitall.Warehouse.Api.Infrastructure.ExceptionHandling.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace Digitall.Warehouse.Api.Extensions;

internal static class ModelBindingExtensions
{
    internal static ValidationErrorResponse ToErrorResponse(this ValueEnumerable values)
    {
        var modelStateEntry = values.FirstOrDefault(v => v.ValidationState == ModelValidationState.Invalid);
        if (modelStateEntry is null)
            return default!;

        var modelEntry = modelStateEntry!.Errors.FirstOrDefault();

        var errorResponse = new ErrorResponse(
            string.Empty,
            modelEntry?.Exception != null ? modelEntry!.Exception.Message : modelEntry!.ErrorMessage);

        return new ValidationErrorResponse(new List<ErrorResponse>() { errorResponse });
    }
}
