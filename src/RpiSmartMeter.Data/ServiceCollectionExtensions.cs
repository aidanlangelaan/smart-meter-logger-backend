using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RpiSmartMeter.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<SmartMeterDbContext>(options => options.UseMySQL(connectionString));
    }
}
