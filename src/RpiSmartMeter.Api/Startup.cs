using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RpiSmartMeter.Business;
using RpiSmartMeter.Data;
using System;
using System.IO;
using System.Reflection;

namespace RpiSmartMeter.Api
{
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
            services.ConfigureDataServices(Configuration["ConnectionStrings:SmartMeterContext"])
                .ConfigureApplicationServices()
                .ConfigureApiServices();

            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            AddSwagger(services);

            services.AddHsts(options => options.MaxAge = TimeSpan.FromDays(365));

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Raspberrypi Smartmeter Reader API",
                    Description = "Web API for registering and displaying the logs sent by the Raspberrypi Smartmeter Logger.",
                    Contact = new OpenApiContact
                    {
                        Name = "Aidan Langelaan",
                        Email = "aidan@langelaan.pro",
                        Url = new Uri("https://twitter.com/aidanlangelaan")
                    },
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Properties", xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }
    }
}
