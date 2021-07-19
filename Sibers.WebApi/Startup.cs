using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sibers.Configuration;
using Sibers.Services.Mappings;
using Sibers.WebApi.Mappings;
using Sibers.WebApi.Middlewares;
using System.Text.Json.Serialization;

namespace Sibers.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApiMappingProfile), typeof(BllMappingProfile));
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }); ;
            services.AddDataAccess();
            services.AddBllServices();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Projects and Employee API";
                    document.Info.Description = "API реализованное для выполнение тестового задания на стажировку в Sibers";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Алексей Голиков",
                        Email = "alexgolikov5@mail.ru",
                        Url = "https://vk.com/alexgolikov00"
                    };
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
