using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digitall.Persistance.EF.Extensions
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddPersistanceEF(
            this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<WarehouseDbContext>(
                    opt => opt.UseSqlServer(configuration.GetConnectionString("WarehouseConnection")));

            return services;
        }
    }
}
