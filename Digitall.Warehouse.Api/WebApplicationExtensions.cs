using Digitall.Persistance.EF.Abstractions;

namespace Digitall.Warehouse.Api
{
    public static class WebApplicationExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dataSeedService = scope.ServiceProvider.GetService<IDataSeedService>();

                if (dataSeedService == null)
                {
                    return host;
                }

                dataSeedService.Seed();
            }

            return host;
        }
    }
}
