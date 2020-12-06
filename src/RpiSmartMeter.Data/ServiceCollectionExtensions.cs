using Microsoft.Extensions.DependencyInjection;

namespace RpiSmartMeter.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
