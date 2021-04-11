using Microsoft.Extensions.DependencyInjection;
using RpiSmartMeter.Services.Interfaces;
using RpiSmartMeter.Services.Services;

namespace RpiSmartMeter.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services) =>
            services.AddTransient<ILoggerService, LoggerService>();
    }
}
