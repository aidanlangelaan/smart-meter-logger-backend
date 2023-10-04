using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SmartMeterLogger.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services,
            string connectionString) =>
            services.AddDbContext<SmartMeterLoggerDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34))));
    }
}