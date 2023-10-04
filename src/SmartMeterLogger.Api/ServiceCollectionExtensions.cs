using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SmartMeterLogger.Api.Models;

namespace SmartMeterLogger.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
    {
        return services;
    }
        
    public static IServiceCollection SetupFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CreateTelegramViewModelValidator>();

        return services;
    }
}