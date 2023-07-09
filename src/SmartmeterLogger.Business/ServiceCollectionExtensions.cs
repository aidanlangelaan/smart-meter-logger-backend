﻿using Microsoft.Extensions.DependencyInjection;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Services;

namespace SmartMeterLogger.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ITelegramService, TelegramService>();

            return services;
        }
    }
}