using Digitall.Warehouse.Application.Abstractions;
using Digitall.Warehouse.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Digitall.Warehouse.Application.Extensions
{
    public static class DependencyRegistrationExentensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidationService, ValidationService>();

            return services;
        }
    }
}
