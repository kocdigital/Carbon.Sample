using Carbon.Sample.API.Domain.Repositories.Abstract;
using Carbon.Sample.API.Domain.Repositories;
using Carbon.Sample.API.Domain.Services.Abstract;
using Carbon.Sample.API.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Carbon.Sample.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<ISampleService, SampleService>();
        }

        public static void AddCustomCors(this IServiceCollection serviceCollection, string cors)
        {
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy(cors, builder =>
                {
                    builder.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }
    }

 
}
