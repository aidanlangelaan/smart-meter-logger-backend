using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RpiSmartMeter.Api.Interceptors;
using RpiSmartMeter.Api.Models;

namespace RpiSmartMeter.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
        {
            return services;
        }
        
        public static IServiceCollection SetupFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RegisterViewModelValidator>();

            return services;
        }
    }
}
