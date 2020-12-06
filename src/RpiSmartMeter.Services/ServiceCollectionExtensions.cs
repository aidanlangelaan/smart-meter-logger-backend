using Microsoft.Extensions.DependencyInjection;

namespace RpiSmartMeter.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
