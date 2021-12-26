using Microsoft.Extensions.DependencyInjection;
using RpiSmartMeter.Business.Interfaces;
using RpiSmartMeter.Business.Services;

namespace RpiSmartMeter.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUsageService, UsageService>();

            return services;
        }
    }
}
