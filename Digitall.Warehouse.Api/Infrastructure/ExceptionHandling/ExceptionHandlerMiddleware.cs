using Digitall.Warehouse.Api.Infrastructure.ExceptionHandling.Models;
using FluentValidation;
using System.Net;

namespace Digitall.Warehouse.Api.Infrastructure.ExceptionHandling
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                HandleException(context, ex);
            }
        }

        private async void HandleException(HttpContext context, ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new ValidationErrorResponse(ex.Errors);
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
