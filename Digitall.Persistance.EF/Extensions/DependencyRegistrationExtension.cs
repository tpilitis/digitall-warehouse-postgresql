using Digitall.Persistance.EF.Repositories;
using Digitall.Persistance.EF.Seeds;
using Digitall.Warehouse.Application;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digitall.Persistance.EF.Extensions;

public static class DependencyRegistrationExtension
{
    public static IServiceCollection AddPersistanceEF(
        this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<WarehouseDbContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("WarehouseConnection")));

        services.AddScoped<IDataSeedService, ProductDataSeedService>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
