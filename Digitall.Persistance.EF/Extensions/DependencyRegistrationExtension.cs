using Digitall.Persistance.EF.Repositories;
using Digitall.Persistance.EF.Repositories.Cached;
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
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddDbContext<WarehouseDbContext>(
                opt => opt.UseNpgsql(configuration.GetConnectionString("WarehouseConnection")));

        services.AddScoped<IDataSeedService, ProductDataSeedService>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.Decorate<IProductRepository, CachedProductsRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
        services.AddScoped<IProductSwatchRepository, ProductSwatchRepository>();
        services.AddScoped<IProductSizeRepository, ProductSizeRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
