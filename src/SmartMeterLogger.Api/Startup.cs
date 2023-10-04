using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartMeterLogger.Business;
using SmartMeterLogger.Data;
using System;
using System.IO;
using System.Reflection;
using SmartMeterLogger.Api.Configurations;
using SmartMeterLogger.Business.configurations;

namespace SmartMeterLogger.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Setup dependency injection
        services.ConfigureDataServices(Configuration["ConnectionStrings:SmartMeterLoggerContext"])
            .ConfigureApplicationServices()
            .ConfigureApiServices();

        services.AddControllers();

        services.AddHsts(options => options.MaxAge = TimeSpan.FromDays(365));

        services.Configure<IISServerOptions>(options =>
        {
            options.AutomaticAuthentication = false;
        });
            
        services.SetupFluentValidation();

        services.AddAutoMapper(typeof(TelegramViewModelMapperProfile), typeof(EntityMapperProfile));

        AddSwagger(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseCors(options => options.AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .Build());
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
            
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "RPI Smart Meter Logger - API");
        });
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Smart Meter Logger - API",
                Description = "Web API for registering and returning the logs sent by the Smart Meter Logger.",
                Contact = new OpenApiContact
                {
                    Name = "Aidan Langelaan",
                    Email = "aidan@langelaan.pro",
                    Url = new Uri("https://www.aidanlangelaan.nl")
                },
            });

            // Set the comments path for the Swagger JSON and UI.
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}