using Microsoft.Extensions.DependencyInjection;

namespace RpiSmartMeter.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
